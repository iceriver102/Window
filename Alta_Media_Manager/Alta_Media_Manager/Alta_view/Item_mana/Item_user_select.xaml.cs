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

namespace Alta_Media_Manager.Alta_view.Item_mana
{
    /// <summary>
    /// Interaction logic for Item_user_select.xaml
    /// </summary>
    public partial class Item_user_select : UserControl
    {
        Class.alta_class_user _user;
        public Item_user_select(Class.alta_class_user user)
        {
            InitializeComponent();
            _user = user;
            this.Fullname = user.alta_full_name;
            this.txt_user_name.Content = user.alta_username;
            this.TypeUser = user.alta_type_user;
            this.Id = user.alta_id;
            this.Width = 298;
            this.Height = 145;
            this.Email = user.alta_email;
            this.Phone = user.alta_phone;
            this.barAction.Visibility = Visibility.Hidden;
            isAdd = false;
            isRemove = false;
        }
        public int Id
        {
            get;
            set;
        }
        public static readonly DependencyProperty FullNameProperty = DependencyProperty.Register("FullName", typeof(String), typeof(Item_user_select),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(FullNameChange)));
        public String Fullname
        {
            get
            {
                return (String)GetValue(FullNameProperty);
            }
            set
            {
                SetValue(FullNameProperty, value);
            }
        }
        private static void FullNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Item_user_select).txt_alta_name.Content = (String)e.NewValue;
        }

        public static readonly DependencyProperty TypeUserProperty = DependencyProperty.Register("TypeUser", typeof(Class.alta_class_user_type), typeof(Item_user_select),
              new FrameworkPropertyMetadata(new PropertyChangedCallback(TypeUserChanged)));
        public Class.alta_class_user_type TypeUser
        {
            get
            {
                return (Class.alta_class_user_type)GetValue(TypeUserProperty);
            }
            set
            {
                SetValue(TypeUserProperty, value);
            }
        }

        private static void TypeUserChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Class.alta_class_user_type type = (Class.alta_class_user_type)e.NewValue;
            (d as Item_user_select).txt_user_type.Content = "Type: " + type.alta_name;
        }

        public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register("Username", typeof(String), typeof(Item_user_select),
             new FrameworkPropertyMetadata(new PropertyChangedCallback(UserNameChange)));

        public String Username
        {
            get
            {
                return (String)GetValue(UsernameProperty);
            }
            set
            {
                SetValue(UsernameProperty, value);
            }
        }

        public static readonly DependencyProperty PhoneProperty = DependencyProperty.Register("Phone", typeof(String), typeof(Item_user_select),
             new FrameworkPropertyMetadata(new PropertyChangedCallback(PhoneChange)));
        public String Phone
        {
            get
            {
                return (String)GetValue(PhoneProperty);
            }
            set
            {
                SetValue(PhoneProperty, value);
            }
        }
        public static readonly DependencyProperty EmailProperty = DependencyProperty.Register("Email", typeof(String), typeof(Item_user_select),
             new FrameworkPropertyMetadata(new PropertyChangedCallback(EmailChange)));

        private static void EmailChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Item_user_select).txt_user_email.Content = "Email: " + e.NewValue;
        }
        public String Email
        {
            get
            {
                return (String)GetValue(EmailProperty);

            }
            set
            {
                SetValue(EmailProperty, value);
            }
        }
        private static void PhoneChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Item_user_select).txt_user_phone.Content = "Phone: " + e.NewValue;
        }


        private static void UserNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Item_user_select).txt_user_type.Content = "Username: " + (string)e.NewValue;
        }

        private void selectItem(object sender, MouseButtonEventArgs e)
        {
            if (SelectItemEvent != null)
            {
                SelectItemEvent(this, this._user);
            }
        }
        public event EventHandler<Class.alta_class_user> SelectItemEvent;
        private bool _showbar;
        public bool ShowBar
        {
            get { return _showbar; }
            set
            {
                _showbar = value;
                if (value)
                {
                    this.Cursor = Cursors.Arrow;
                    this.barAction.Visibility = Visibility.Visible;
                }
                else
                {
                    this.Cursor = Cursors.Hand;
                    this.barAction.Visibility = Visibility.Hidden;
                }

            }
        }
        private void HidebarAction(object sender, MouseEventArgs e)
        {
            this.barAction.Visibility = Visibility.Hidden;
        }
        private void ShowbarAction(object sender, MouseEventArgs e)
        {
            if (ShowBar)
            {
                this.barAction.Visibility = Visibility.Visible;
            }
        }

        private void btnRemoveClick(object sender, RoutedEventArgs e)
        {
            if(RemoveEvent!=null)
                RemoveEvent(this, _user);
        }
        public event EventHandler<Class.alta_class_user> RemoveEvent;
        public event EventHandler<Class.alta_class_user> AddEvent;
        private bool _isRemove;
        public bool isRemove
        {
            get
            {
                return _isRemove;
            }
            set
            {
                _isRemove = value;
                if (_isRemove)
                {
                    this.removeBtn.Visibility = Visibility.Visible;
                }
                else
                {
                    this.removeBtn.Visibility = Visibility.Hidden;
                }
            }
        }
        private bool _isAdd;
        public bool isAdd
        {
            get
            {
                return _isAdd;
            }
            set
            {
                _isAdd = value;
                if(value)
                {
                    this.Addbtn.Visibility=Visibility.Visible;
                }
                else
                {
                    this.Addbtn.Visibility = Visibility.Hidden;
                }
            }
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            if (AddEvent != null)
                AddEvent(this, _user);
        }

    }
}
