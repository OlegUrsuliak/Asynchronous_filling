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
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Windows.Shapes;



namespace System.Examen {
    public partial class MainWindow : Window {
        Random rand;
        public MainWindow() {
            InitializeComponent();
            rand = new Random();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e) {
            Close();
        }
        void ProgresBarStart(ProgressBar progressbar) {
            int s = 0;
            while(s <=100) {

                Thread.Sleep(100);

                if(rand.Next(0,3) == 0 && s<=100) {
                    s += rand.Next(0,12);
                    Dispatcher.Invoke(() => progressbar.Value = s);
                }
                
                else {
                    s -= rand.Next(0,12);

                    if(s<=0) {Dispatcher.Invoke(() => progressbar.Value += 0);}
                    Dispatcher.Invoke(() => progressbar.Value = s);
                    if(s >= 100)
                        s = 70;
                    if(s <= 0)
                        s = 20;
                }
            }
        }
        async void ProgresBarStartAsync(ProgressBar progressbar) {
            await Task.Run(() => ProgresBarStart(progressbar));
        }



        private void buttonStart_Click(object sender, RoutedEventArgs e) {
            ProgresBarStartAsync(progressBar1);ProgresBarStartAsync(progressBar2);ProgresBarStartAsync(progressBar3);ProgresBarStartAsync(progressBar4);ProgresBarStartAsync(progressBar5);
        }
    }
}
