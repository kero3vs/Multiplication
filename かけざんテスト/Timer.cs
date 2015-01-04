using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace かけざんテスト
{
    /// <summary>
    /// カウントダウンタイマー(分のみ)
    /// </summary>
    /// 指定時間(3分など)を受け取り、その時間のミリ秒をメモリに格納。
    /// ストップウォッチの値からその時間を引いた値を表示する。
    class Timer : INotifyPropertyChanged
    {
        private long setTime;
        public string NowTime { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        Stopwatch wc = new Stopwatch();

        public Timer(int t)
        {
            setTime = t * 60 * 1000;
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

                long time = setTime - wc.ElapsedMilliseconds;
                TimeSpan ts = new TimeSpan(time*1000*10);
                //TimeSpan ts = wc.Elapsed;

                // Format and display the TimeSpan value.
                NowTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("NowTime"));
                    //指定時間を過ぎたことを通知する
                    if (time <= 0)
                    {
                        System.Windows.MessageBox.Show("おしまい");
                        reset();
                        
                    }
                }
                    

            }
        }

    }
}
