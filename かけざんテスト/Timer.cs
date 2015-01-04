using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace かけざんテスト
{
    class Timer : INotifyPropertyChanged
    {
        public string NowTime { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        Stopwatch wc = new Stopwatch();

        public Timer()
        {

            Run();
        }


        public void start()
        {
            wc.Start();
        }

        public void reset()
        {
            

            if (this.PropertyChanged != null)
            {
                wc.Reset();
                this.PropertyChanged(this, new PropertyChangedEventArgs("NowTime"));
            }

        }

        public async void Run()
        {

            while (true)
            {
                await Task.Delay(10);

                TimeSpan ts = wc.Elapsed;

                // Format and display the TimeSpan value.
                NowTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("NowTime"));
                    //指定時間を過ぎたことを通知する(1分)
                    if (ts.Minutes >= 2)
                    {
                        System.Windows.MessageBox.Show("おしまい");
                        reset();
                        
                    }
                }
                    

            }
        }

    }
}
