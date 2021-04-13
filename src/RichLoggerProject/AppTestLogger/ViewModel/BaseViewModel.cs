﻿using RichLogger;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace AppTestLogger.ViewModel
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
        /// <summary>
        /// Contient tous les logs.
        /// </summary>
        public ObservableCollection<LogInfo> Logs
        {

            get { return _logs; }

            set

            {

                _logs = value;
                OnNotifyPropertyChanged();

            }

        }
        private ObservableCollection<LogInfo> _logs;


		public BaseViewModel()
		{
            _logs = new ObservableCollection<LogInfo>();
		}


        #region Methodes pour les logs

        /// <summary>
        /// Ajout dans LogInformation, les nouvelles informations pour faire
        /// l'affichage.
        /// </summary>
        /// <param name="message"></param>
        public void LogInformation(LogInfo message)
        {
            if (App.Current.Dispatcher.CheckAccess())
            {
                Logs.Add(message);
            }
            else
            {
                App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Logs.Add(message);
                }));
            }
        }

        public void LogInformation(string message)
        {
            if (App.Current.Dispatcher.CheckAccess())
            {
                Logs.Add(new LogInfo(StatusLog.Information, message));
            }
            else
            {
                App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Logs.Add(new LogInfo(StatusLog.Information, message));
                }));
            }
        }

        public void LogError(string message)
        {
            if (App.Current.Dispatcher.CheckAccess())
            {
                Logs.Add(new LogInfo(StatusLog.Error, message));
            }
            else
            {
                App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Logs.Add(new LogInfo(StatusLog.Error, message));
                }));
            }
        }

        public void LogWarning(string message)
        {
            if (App.Current.Dispatcher.CheckAccess())
            {
                Logs.Add(new LogInfo(StatusLog.Warn, message));
            }
            else
            {
                App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Logs.Add(new LogInfo(StatusLog.Warn, message));
                }));
            }
        }

        public void LogSuccess(string message)
        {
            if (App.Current.Dispatcher.CheckAccess())
            {
                Logs.Add(new LogInfo(StatusLog.InfoGreen, message));
            }
            else
            {
                App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Logs.Add(new LogInfo(StatusLog.InfoGreen, message));
                }));
            }
        }


        public void ResetLog()
        {
            if (App.Current.Dispatcher.CheckAccess())
            {
                Logs = new ObservableCollection<LogInfo>();
            }
            else
            {
                App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Logs = new ObservableCollection<LogInfo>();
                }));
            }
        }


        #endregion


        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


		protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(memberName));
			}
		}

		#endregion
	}
}
