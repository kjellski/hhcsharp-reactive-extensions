using System;
using System.Reactive.Subjects;
using System.Windows;
using System.Windows.Input;

namespace _04_Rx_Events
{
    public partial class MainWindow
    {
        private readonly Subject<Point> _mousePostion = new Subject<Point>();
        public const String Text = "C# .Net Hamburg";

        public MainWindow()
        {
            InitializeComponent();
            _mousePostion.Subscribe(point => Title = String.Format("X: {0,-5} Y: {1,-5}", point.X, point.Y));
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            _mousePostion.OnNext(e.GetPosition(this));
        }
    }
}