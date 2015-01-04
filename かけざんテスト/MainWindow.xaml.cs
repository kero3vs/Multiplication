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
using System.Diagnostics;

namespace かけざんテスト
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        public static int TOTAL_QUESTION = 15;

        Timer watch = new Timer();

        Logic logic = new Logic();

        int position = 0;
        int ok = 0;
        int ng = 0;

        TextBox[] tboxCol = new TextBox[TOTAL_QUESTION];
        TextBox[] tboxAnswer = new TextBox[TOTAL_QUESTION];
        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = logic;
            Timer.DataContext = watch;

            for (int i = 0; i < TOTAL_QUESTION; i++)
            {
                tboxCol[i] = new TextBox();
                tboxAnswer[i] = new TextBox();
                tboxCol[i].Text = (i + 1) + "問目";
                tboxAnswer[i].Text = "";
                tboxCol[i].Width = 50;
                tboxAnswer[i].Width = 50;
                ColName.Children.Add(tboxCol[i]);
                AnswerList.Children.Add(tboxAnswer[i]);
            }
 

        }

        private void clear()
        {

            for (int i = 0; i < TOTAL_QUESTION; i++)
            {

                tboxAnswer[i].Text = "";

            }
            position = 0;
            ok = 0;
            ng = 0;

        }

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            watch.start();
            setQuestion();

        }


        private void setQuestion()
        {
            logic.setNum();

            int pattern = logic.getFromZeroToTwo();

            switch (pattern)
            {
                case 0:
                    LeftBox.Text = "";
                    LeftBox.IsReadOnly = false;
                    RightBox.IsReadOnly = true;
                    AnserBox.IsReadOnly = true;
                    Keyboard.Focus(LeftBox);
                    break;
                case 1:
                    RightBox.Text = "";
                    RightBox.IsReadOnly = false;
                    LeftBox.IsReadOnly = true;
                    AnserBox.IsReadOnly = true;
                    Keyboard.Focus(RightBox);
                    break;
                case 2:
                    AnserBox.Text = "";
                    AnserBox.IsReadOnly = false;
                    LeftBox.IsReadOnly = true;
                    RightBox.IsReadOnly = true;
                    Keyboard.Focus(AnserBox);
                    break;
            }
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            bool answer = answerCheck();
            if (answer)
            {
                MessageBox.Show("せいかい");
                tboxAnswer[position].Text = "○";
                ok++;
            }
            else
            {
                MessageBox.Show("まちがい");
                tboxAnswer[position].Text = "×";
                ng++;
            }
            position++;
            if (position == TOTAL_QUESTION)
            {
                result();
            }
            else {
                setQuestion();

            }
            
        }

        private void result()
        {
            if (ok == TOTAL_QUESTION)
            {
                MessageBox.Show("全問せいかいです。");
            }
            else
            {
                MessageBox.Show(TOTAL_QUESTION + "門中" + ng + "問まちがえました。しっぱいです。");
            }
            clear();
        }


        private bool answerCheck()
        {
            int numLeft;
            int numRight;
            int numAnser;
            try
            {
                numLeft = Int32.Parse(LeftBox.Text);
                numRight = Int32.Parse(RightBox.Text);
                numAnser = Int32.Parse(AnserBox.Text);
            }
            catch (Exception e)
            {
                return false;
            }
            if (numLeft * numRight == numAnser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
}
