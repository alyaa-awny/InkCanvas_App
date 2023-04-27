using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfDay1
{
    /// <summary>
    /// Interaction logic for InkCanv.xaml
    /// </summary>
    public partial class InkCanv : Window
    {

        public InkCanv()
        {
            InitializeComponent();
        }

        private void Change_Color(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Content.ToString())
            {

                case "Red":
                    ink.DefaultDrawingAttributes.Color = Colors.Red;
                    break;

                case "Green":
                    ink.DefaultDrawingAttributes.Color = Colors.Green;
                    break;

                case "Blue":
                    ink.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
            }



        }

        private void Change_Mode(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Content.ToString())
            {
                case "Ink":
                    ink.EditingMode = InkCanvasEditingMode.Ink;
                    break;

                case "Select":
                    ink.EditingMode = InkCanvasEditingMode.Select;
                    break;



                case "Erase":
                    ink.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;


                case "EraseByStrock":
                    ink.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;

            }
        }
        public void drawCircleAp(Double EHeight, Double EWidth, InkCanvas surface)
        {
            Ellipse e1 = new Ellipse();
            e1.Width = EWidth;
            e1.Height = EHeight;
            var brush = new SolidColorBrush();
            brush.Color = Color.FromArgb(100, 0, 0, 0);
            e1.Stroke = brush;
            e1.StrokeThickness = 4;
            surface.Children.Add(e1);
        }
        private void shape(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Content.ToString())
            {
                case "Ellipse":
                    ink.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                    break;
                case "Rectangle":
                    ink.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
                    break;

            }
        }

        private void Brush_size(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Content.ToString())
            {
                case "Small":
                    ink.DefaultDrawingAttributes.Width = 5;
                    ink.DefaultDrawingAttributes.Height = 5;
                    break;
                case "Normal":
                    ink.DefaultDrawingAttributes.Width = 10;
                    ink.DefaultDrawingAttributes.Height = 10;
                    break;
                case "Large":
                    ink.DefaultDrawingAttributes.Width = 15;
                    ink.DefaultDrawingAttributes.Height = 15;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "New_Btn":
                    {
                        ink.Strokes.Clear();
                    }
                    break;
                case "Paste_Btn":


                    ink.Paste();

                    break;
                case "Copy_Btn":
                    ink.CopySelection();
                    break;
                case "Save_Btn":
                    {
                        SaveFileDialog SaveFileShap = new SaveFileDialog();
                        SaveFileShap.Filter = "InkanvasFormat|*.alyaa";
                        SaveFileShap.Title = "Save Inkcanvace Fill";
                        SaveFileShap.ShowDialog();
                        if (SaveFileShap.FileName == "") return;
                        FileStream fs = File.Open(SaveFileShap.FileName, FileMode.OpenOrCreate);
                        ink.Strokes.Save(fs);
                    }
                    break;
                case "Load_Btn":
                    {
                        OpenFileDialog openSavedShape = new OpenFileDialog();
                        openSavedShape.Title = "Load Inkcanvas File";
                        openSavedShape.DefaultExt = "sandy";
                        openSavedShape.Filter = "InkanvasFormat|*.alyaa";
                        openSavedShape.ShowDialog();
                        if (openSavedShape.FileName == "") return;
                        FileStream fs = File.Open(openSavedShape.FileName, FileMode.Open);
                        StrokeCollection myStroke = new StrokeCollection(fs);
                        ink.Strokes = myStroke;
                        fs.Close();
                    }
                    break;
                case "Cut_Btn":
                    ink.CutSelection();
                    break;
            }
        }
    }
}
