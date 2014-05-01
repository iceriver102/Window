using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alta_Media_Manager.Plugin
{
    /// <summary>
    /// Interaction logic for dateChoose.xaml
    /// </summary>
    public partial class dateChoose : Canvas
    {
        private VisualCollection controls;
        private DatePicker textBox;
        public DateTime? data;
        private bool insertText;
        public dateChoose()
        {
            controls = new VisualCollection(this);
            InitializeComponent();
            textBox = new DatePicker();
            textBox.SelectedDateChanged += textBox_SelectedDateChanged;
           // textBox.MouseEnter += textBox_MouseEnter;
            textBox.VerticalContentAlignment = VerticalAlignment.Center;
            controls.Add(textBox);
        }

        private void textBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            data = textBox.SelectedDate;
        }    
        public string Text
        {
            get { return textBox.Text; }
            set
            {
                insertText = true;
                textBox.Text = value;
            }
        }
        protected override Visual GetVisualChild(int index)
        {
            return controls[index];
        }

        protected override int VisualChildrenCount
        {
            get { return controls.Count; }
        }
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            textBox.Arrange(new Rect(arrangeSize));
            return base.ArrangeOverride(arrangeSize);
        }
    }
}
