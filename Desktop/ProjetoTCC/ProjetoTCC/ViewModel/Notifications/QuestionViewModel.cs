using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetoTCC.ViewModel
{
    public class QuestionViewModel : Base
    {
        private string timeCount;
        private int duration;
        private string title;
        private string question;
        private string resp1;
        private string resp2;
        public string TimeCount
        {
            get
            {
                return timeCount;
            }
            set
            {
                timeCount = value;
                RaisePropertyChanged("TimeCount");
            }
        }
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
                RaisePropertyChanged("Duration");
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }
        public string Question
        {
            get
            {
                return question;
            }
            set
            {
                question = value;
                RaisePropertyChanged("Question");
            }
        }

        public string Resp1
        {
            get
            {
                return resp1;
            }
            set
            {
                resp1 = value;
                RaisePropertyChanged("Resp1");
            }
        }
        public string Resp2
        {
            get
            {
                return resp2;
            }
            set { resp2 = value;
                RaisePropertyChanged("Resp2");
            }
        }

        public QuestionViewModel(string question, string title, int duration, string resp1, string resp2)
        {
            Question = question;
            Title = title;
            Duration = duration;
            Resp1 = resp1;
            Resp2 = resp2;
            TimeCount = Duration.ToString() + "s";
            Common.Time.KeepExecuting(UpdateCount);
        }


        private void UpdateCount(object sender, EventArgs e)
        {
            Duration -= 1;
            TimeCount = Duration.ToString() + "s";
            if (Duration == 0) Close();
            CommandManager.InvalidateRequerySuggested();
        }
    }
}

