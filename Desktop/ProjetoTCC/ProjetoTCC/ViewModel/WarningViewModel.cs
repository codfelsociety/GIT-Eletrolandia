using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetoTCC.ViewModel
{
    public class WarningViewModel : Base
    {
        private string timeCount;
        private int duration;
        private string title;
        private string message;

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
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                RaisePropertyChanged("Message");
            }
        }

        public WarningViewModel(string message, string title, int duration)
        {
            Message = message;
            Title = title;
            Duration = duration;
            TimeCount = Duration.ToString() + "s" ;
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
