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
using System.Windows.Threading;

namespace TrayApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Değişkenler
        List<string> iconlar = new List<string> {  "mavi.ico", "kahve.ico", "turuncu.ico", "siyah.ico", "yesil.ico", "" };
        string picture;
        string picture2;

        static int m_counter = 0;
        System.Windows.Forms.NotifyIcon notifyicon = new System.Windows.Forms.NotifyIcon();
        public MainWindow()
        {
            var timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
            picture = iconlar[m_counter].ToString();
            notifyicon.Icon = new System.Drawing.Icon(picture);
            notifyicon.Visible = true;
            notifyicon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyicon_click);
            System.Windows.Forms.ContextMenu notifycontextmenu = new System.Windows.Forms.ContextMenu();
            notifycontextmenu.MenuItems.Add("Göster", new EventHandler(goster));
            notifycontextmenu.MenuItems.Add("Gizle", new EventHandler(gizle));
            notifycontextmenu.MenuItems.Add("Çıkış", new EventHandler(cikis));
            notifycontextmenu.MenuItems.Add("Tam Ekran", new EventHandler(tamekran));
            notifyicon.ContextMenu = notifycontextmenu;
            InitializeComponent();
        }

        private void tamekran(object sender, EventArgs e)
        {
            this.Show();
            WindowState = WindowState.Maximized;
        }

        private void cikis(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gizle(object sender, EventArgs e)
        {
            notifyicon.ShowBalloonTip(3000, "Gizlendi.", "icon üzerine sağ tıklayarak tekrar görüntüleme yapabilirsiniz..", System.Windows.Forms.ToolTipIcon.Info);
            this.Hide();
        }

        private void goster(object sender, EventArgs e)
        {
            this.Show();
            WindowState = WindowState.Normal;
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            picture2 = iconlar[m_counter].ToString();
            notifyicon.Icon = new System.Drawing.Icon(picture2);
            notifyicon.Visible = true;
            if (m_counter == 4)
            {
                m_counter = 0;
            }
            m_counter++;
        }

        private void notifyicon_click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (WindowState==WindowState.Minimized)
            {
                this.Show();
                WindowState = WindowState.Normal;
            }
            else
            {
                notifyicon.ShowBalloonTip(3000, "Gizlendi.", "icon üzerine tıklayarak tekrar görüntüleme yapabilirsiniz..", System.Windows.Forms.ToolTipIcon.Info);
                WindowState = WindowState.Minimized;
            }
           
        }


    }
}
