using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Diplom
{
    public partial class StinkBugs : Form
    {
        private System.Windows.Forms.Timer gameTimer;
        private List<Drone> drones;
        private List<Tree> trees;
        private Random random;
        private Point storageLocation;
        private const int storageSize = 100;
        private int storageFruits;
        private Label totalFruitsLabel;

        public StinkBugs()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Close_ESC);

            drones = new List<Drone>();
            trees = new List<Tree>();
            random = new Random();
            storageLocation = new Point(panel2.Width - storageSize, 0);
            storageFruits = 0;

            // Setup game timer
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20; // Update game state every 20 ms
            gameTimer.Tick += new EventHandler(GameUpdate);
            gameTimer.Start();

            panel2.Paint += new PaintEventHandler(Panel2_Paint);

            // Generate drones
            GenerateDrones(10); // Adjust the number of drones as needed

            // Generate trees
            GenerateTrees(10); // Adjust the number of trees as needed

            // Setup label for total fruits on trees
            totalFruitsLabel = new Label();
            totalFruitsLabel.Location = new Point(10, 10);
            totalFruitsLabel.AutoSize = true;
            panel1.Controls.Add(totalFruitsLabel);

            UpdateTotalFruitsLabel();
        }

        private void Close_ESC(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void GameUpdate(object sender, EventArgs e)
        {
            foreach (var drone in drones)
            {
                drone.Update(panel2.Width, panel2.Height, trees, storageLocation, storageSize, ref storageFruits, drones); // Передаємо список дронів для перевірки можливості допомоги
            }
            CheckDroneConnections();
            UpdateTotalFruitsLabel();
            panel2.Invalidate(); // Force panel to repaint
        }

        private void CheckDroneConnections()
        {
            foreach (var drone in drones)
            {
                drone.InContact = false; // Reset contact status
            }

            for (int i = 0; i < drones.Count; i++)
            {
                for (int j = i + 1; j < drones.Count; j++)
                {
                    if (drones[i].IsInContact(drones[j]))
                    {
                        drones[i].InContact = true;
                        drones[j].InContact = true;
                        if (drones[i].NeedHelp)
                        {
                            drones[j].HelpDrone = drones[i];
                        }
                    }

                }
            }
        }



        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush droneBrush = Brushes.Red;
            Brush treeBrush = Brushes.Green;
            Brush storageBrush = Brushes.Pink;
            Pen connectionPen = new Pen(Color.Blue, 1);
            Font font = new Font("Arial", 8);
            Brush textBrush = Brushes.Black;

            // Draw storage
            g.FillRectangle(storageBrush, new Rectangle(storageLocation.X, storageLocation.Y, storageSize, storageSize));
            g.DrawString($"{storageFruits} фруктів", font, textBrush, storageLocation.X, storageLocation.Y + storageSize + 5);

            // Draw drones
            foreach (var drone in drones)
            {
                g.FillRectangle(droneBrush, new Rectangle(drone.Position.X, drone.Position.Y, 10, 10));

                // Draw connection radius
                g.DrawEllipse(connectionPen, drone.Position.X - drone.ConnectionRadius, drone.Position.Y - drone.ConnectionRadius, drone.ConnectionRadius * 2, drone.ConnectionRadius * 2);

                // Draw status text
                if (drone.InContact)
                {
                    g.DrawString("Connect", font, textBrush, drone.Position.X, drone.Position.Y - 15);
                }
                if (drone.Collecting)
                {
                    g.DrawString("Collecting", font, textBrush, drone.Position.X, drone.Position.Y - 25);
                }
                if (drone.NeedHelp)
                {
                    g.DrawString("I need help", font, textBrush, drone.Position.X, drone.Position.Y - 35);
                }
                g.DrawString($"{drone.FruitsCollected} фруктів", font, textBrush, drone.Position.X, drone.Position.Y - 45);
            }

            // Draw trees and fruits
            foreach (var tree in trees)
            {
                g.FillRectangle(treeBrush, new Rectangle(tree.Position.X, tree.Position.Y, 20, 20)); // Example tree size
                g.DrawString($"{tree.Fruits} плодів", font, textBrush, tree.Position.X, tree.Position.Y - 15);
            }
        }

        private void GenerateDrones(int numberOfDrones)
        {
            for (int i = 0; i < numberOfDrones; i++)
            {
                int x = random.Next(panel2.Width - 10);
                int y = random.Next(panel2.Height - 10);
                int dx = random.Next(-5, 6); // Random direction X
                int dy = random.Next(-5, 6); // Random direction Y
                int connectionRadius = 75; // Set a default connection radius

                // Ensure direction is not zero
                if (dx == 0) dx = 1;
                if (dy == 0) dy = 1;

                drones.Add(new Drone(new Point(x, y), dx, dy, connectionRadius));
            }
        }

        private void GenerateTrees(int numberOfTrees)
        {
            for (int i = 0; i < numberOfTrees; i++)
            {
                int x = random.Next(panel2.Width - 20); // Adjust for tree width
                int y = random.Next(panel2.Height - 20); // Adjust for tree height
                int fruits = random.Next(15, 24); // Random number of fruits between 37 and 95
                trees.Add(new Tree(new Point(x, y), fruits));
            }
        }

        private void UpdateTotalFruitsLabel()
        {
            int totalFruits = trees.Sum(tree => tree.Fruits);
            totalFruitsLabel.Text = $"Загальна кількість плодів на деревах: {totalFruits}";
        }
    }

    public class Drone
    {
        public Point Position { get; private set; }
        private int dx;
        private int dy;
        private Random random;
        public bool IsWaiting { get; private set; }
        public int ConnectionRadius { get; private set; }
        public bool InContact { get; set; }
        public bool Collecting { get; private set; }
        public bool NeedHelp { get; private set; }
        public int FruitsCollected { get; private set; }
        private const int MaxFruits = 15;
        public Drone HelpDrone { get; set; }
        private Tree targetTree;
        private DateTime collectStartTime;
        private DateTime helpRequestTime;
        private const int maxCollectingTime = 2000; // 2 секунди у мілісекундах
        private const int maxHelpRequestTime = 3500; // 1.5 секунди у мілісекундах
        private const int maxTreeFruitsForHelp = 15;
        private const int helpWaitTime = 7000;

        public void RequestHelp()
        {
            NeedHelp = true;
            helpRequestTime = DateTime.Now;
        }

        public bool CanHelp(Drone otherDrone)
        {
            return !NeedHelp && FruitsCollected < MaxFruits && otherDrone.FruitsCollected > 0 && !otherDrone.NeedHelp && IsInContact(otherDrone);
        }

        public Drone(Point startPosition, int dx, int dy, int connectionRadius)
        {
            this.Position = startPosition;
            this.dx = dx;
            this.dy = dy;
            this.ConnectionRadius = connectionRadius;
            this.InContact = false;
            this.Collecting = false;
            this.NeedHelp = false;
            this.FruitsCollected = 0;
            this.HelpDrone = null;
            this.random = new Random();
        }

        public void Update(int panelWidth, int panelHeight, List<Tree> trees, Point storageLocation, int storageSize, ref int storageFruits, List<Drone> allDrones)
        {
            bool treeHasFruit = false;
            foreach (var tree in trees)
            {
                if (tree.Fruits > 0)
                {
                    treeHasFruit = true;
                    break;
                }
            }
            bool noHelpRequested = (DateTime.Now - helpRequestTime).TotalMilliseconds >= 7000;


            // Check if collecting time exceeded
            if (Collecting)
            {
                if ((DateTime.Now - collectStartTime).TotalMilliseconds >= maxCollectingTime)
                {
                    Collecting = false;
                }
                else
                {
                    CollectFruits();
                    return;
                }
            }

            // Check if help request time exceeded
            if (MaxFruits >= FruitsCollected)
            {
                if ((DateTime.Now - helpRequestTime).TotalMilliseconds >= maxHelpRequestTime)
                {
                    NeedHelp = false;
                }
                else
                {
                    MoveTowards(HelpDrone.Position);
                    return;
                }
            }

            if (NeedHelp)
            {
                foreach (var otherDrone in allDrones)
                {
                    if (otherDrone.CanHelp(this))
                    {
                        otherDrone.MoveTowards(Position);
                        if (IsAtLocation(otherDrone.Position, 10)) // Якщо інший дрон підлетів до поточного
                        {
                            int fruitsToTransfer = Math.Min(MaxFruits - FruitsCollected, otherDrone.FruitsCollected);
                            FruitsCollected += fruitsToTransfer;
                            otherDrone.FruitsCollected -= fruitsToTransfer;
                            break; // Зупиняємо пошук допомоги після того, як знайдено першого дрона для допомоги
                        }
                    }
                }
                return;
            }

            if (FruitsCollected < MaxFruits && NeedHelp)
            {
                foreach (var otherDrone in allDrones)
                {
                    if (CanHelp(otherDrone))
                    {
                        MoveTowards(otherDrone.Position);
                        if (IsAtLocation(otherDrone.Position, 10)) // Якщо інший дрон підлетів до поточного
                        {
                            int fruitsToTransfer = Math.Min(MaxFruits - FruitsCollected, otherDrone.FruitsCollected);
                            FruitsCollected += fruitsToTransfer;
                            otherDrone.FruitsCollected -= fruitsToTransfer;
                            if (FruitsCollected >= MaxFruits)
                            {
                                NeedHelp = false;
                                break; // Зупиняємо пошук допомоги після досягнення максимуму плодів
                            }
                        }
                    }
                }
                return;
            }


            if (FruitsCollected >= MaxFruits)
            {
                MoveTowards(storageLocation);
                if (IsAtLocation(storageLocation, storageSize))
                {
                    storageFruits += FruitsCollected; // Add collected fruits to storage
                    FruitsCollected = 0; // Drop off fruits
                }
                return;
            }

            if (targetTree != null)
            {
                if (targetTree.Fruits > 0)
                {
                    MoveTowards(targetTree.Position);
                    if (IsAtLocation(targetTree.Position, 20) && targetTree.Fruits > 0)
                    {
                        StartCollecting(targetTree);
                    }
                }
                else
                {
                    targetTree = null; // Якщо на дереві більше немає плодів, перестаємо його цілити
                    ChooseRandomDirection(); // Випадковий напрямок
                }
                return;
            }

            // Move randomly and search for trees with fruits
            Move(panelWidth, panelHeight);
            foreach (var tree in trees)
            {
                if (tree.Fruits > 0 && IsWithinRadius(tree.Position, ConnectionRadius))
                {
                    targetTree = tree;
                    break;
                }
            }
        }

        private void ChooseRandomDirection()
        {
            dx = random.Next(-5, 6);
            dy = random.Next(-5, 6);
            if (dx == 0) dx = 1;
            if (dy == 0) dy = 1;
        }

        private void MoveTowards(Point target)
        {
            int dx = target.X - Position.X;
            int dy = target.Y - Position.Y;
            if (dx != 0) Position = new Point(Position.X + Math.Sign(dx), Position.Y);
            if (dy != 0) Position = new Point(Position.X, Position.Y + Math.Sign(dy));
        }

        private bool IsAtLocation(Point location, int size)
        {
            return Math.Abs(Position.X - location.X) < size && Math.Abs(Position.Y - location.Y) < size;
        }

        private bool IsWithinRadius(Point location, int radius)
        {
            return Math.Sqrt(Math.Pow(Position.X - location.X, 2) + Math.Pow(Position.Y - location.Y, 2)) <= radius;
        }

        private void Move(int panelWidth, int panelHeight)
        {
            Position = new Point(Position.X + dx, Position.Y + dy);

            // Bounce off walls
            if (Position.X < 0 || Position.X > panelWidth - 10) dx = -dx;
            if (Position.Y < 0 || Position.Y > panelHeight - 10) dy = -dy;
        }

        private void StartCollecting(Tree tree)
        {
            IsWaiting = true;
            Collecting = true;
            collectStartTime = DateTime.Now;
            tree.Fruits -= 1; // Decrease fruits on tree
            FruitsCollected += 1; // Increase fruits collected by drone
        }
        public void CollectFruits()
        {
            if (targetTree.Fruits > 0 && (DateTime.Now - collectStartTime).TotalMilliseconds >= 1000) // Перевірка, чи є плоди на дереві та чи пройшов достатній час для збору
            {
                int fruitsToCollect = Math.Min(15, targetTree.Fruits); // максимум 15 плодів за раз
                if (FruitsCollected + fruitsToCollect <= 15) // Перевірка, щоб не забрати більше плодів, ніж можна
                {
                    FruitsCollected += fruitsToCollect; // Збільшення лічильника зібраних плодів
                    targetTree.Fruits -= fruitsToCollect; // Зменшення кількості плодів на дереві
                    collectStartTime = DateTime.Now; // Оновлення часу початку збирання
                    if (targetTree.Fruits == 0) // Якщо на дереві більше немає плодів
                    {
                        Collecting = false; // Зупиняємо збір
                        targetTree = null; // Очищаємо вибране дерево
                        NeedHelp = false; // Скасовуємо запит про допомогу
                    }
                    else
                    {
                        RequestHelp(); // Запит про допомогу
                    }
                }
            }
        }

        public bool IsInContact(Drone otherDrone)
        {
            int distance = (int)Math.Sqrt(Math.Pow(Position.X - otherDrone.Position.X, 4) + Math.Pow(Position.Y - otherDrone.Position.Y, 4));
            return distance <= ConnectionRadius;
        }
    }

    public class Tree
    {
        public Point Position { get; private set; }
        public int Fruits { get; set; }

        public Tree(Point position, int fruits)
        {
            this.Position = position;
            this.Fruits = fruits;
        }
    }
}
