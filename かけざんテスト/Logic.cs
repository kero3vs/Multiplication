using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace かけざんテスト
{
    public class Logic :INotifyPropertyChanged
    {
        Random rand = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public int leftNum{
            set;
            get;
        }
        public int rightNum
        {
            set;
            get;
        }
        public int answerNum
        {
            set;
            get;
        }


        public Logic()
        {
            leftNum = 0;
            rightNum = 0;
            answerNum = 0;
        }

        /// <summary>
        /// 2から9までの数字をランダムで返す
        /// </summary>
        /// <returns>2から9までの数字</returns>
        private int getFromTwoToNine()
        {
            while (true)
            {
                int num = rand.Next(9);
                if (num != 0)
                {
                    return num + 1;
                }
            }
            

        }

        /// <summary>
        /// 0から2までの数字をランダムで返す
        /// </summary>
        /// <returns>0から2までの数字</returns>
        public int getFromZeroToTwo()
        {
            return rand.Next(3);
        }

        /// <summary>
        /// 問題のセット
        /// </summary>
        public void setNum()
        {
            leftNum = getFromTwoToNine();
            rightNum = getFromTwoToNine();
            answerNum = leftNum * rightNum;
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs("leftNum"));
                this.PropertyChanged(this, new PropertyChangedEventArgs("rightNum"));
                this.PropertyChanged(this, new PropertyChangedEventArgs("answerNum"));
            }
        }
    }
}
