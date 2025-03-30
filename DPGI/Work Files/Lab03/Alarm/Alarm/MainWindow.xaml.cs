using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace DigitalAlarmClock
{
    public partial class MainWindow : Window
    {
        private string _alarmHour;
        private string _alarmMinute;
        private string _alarmSecond;
        private string _alarmMessage;
        private DispatcherTimer _clockTimer;
        private SoundPlayer _alarmSoundPlayer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAlarmSound();
        }

        private void InitializeAlarmSound()
        {
            // Шлях до звукового файлу (можна змінити)
            try
            {
                _alarmSoundPlayer = new SoundPlayer("alarm.wav");
            }
            catch
            {
                // Якщо файл не знайдено, використовувати системний звук
                _alarmSoundPlayer = new SoundPlayer();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeClock();
            PopulateTimeComboBoxes();
        }

        private void InitializeClock()
        {
            _clockTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _clockTimer.Tick += UpdateClock;
            _clockTimer.Start();
            UpdateClock(null, null);
        }

        private void PopulateTimeComboBoxes()
        {
            // Заповнення годин
            for (int hour = 0; hour < 24; hour++)
            {
                HoursComboBox.Items.Add(hour.ToString("00"));
            }

            // Заповнення хвилин і секунд
            for (int minute = 0; minute < 60; minute++)
            {
                MinutesComboBox.Items.Add(minute.ToString("00"));
                SecondsComboBox.Items.Add(minute.ToString("00"));
            }
        }

        private void UpdateClock(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            CurrentTimeText.Text = now.ToString("HH:mm:ss");
            CurrentDateText.Text = now.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("uk-UA"));

            CheckAlarm();
        }

        private void CheckAlarm()
        {
            if (string.IsNullOrEmpty(_alarmHour) || string.IsNullOrEmpty(_alarmMinute) || string.IsNullOrEmpty(_alarmSecond))
                return;

            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            string alarmTime = $"{_alarmHour.PadLeft(2, '0')}:{_alarmMinute.PadLeft(2, '0')}:{_alarmSecond.PadLeft(2, '0')}";

            if (currentTime == alarmTime)
            {
                TriggerAlarm();
            }
        }

        private void TriggerAlarm()
        {
            try
            {
                _alarmSoundPlayer.Play();
                MessageBox.Show(_alarmMessage, "Будильник!", MessageBoxButton.OK, MessageBoxImage.Information);

                // Скидаємо будильник після спрацювання
                ResetAlarm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при відтворенні звуку: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetAlarm()
        {
            _alarmHour = null;
            _alarmMinute = null;
            _alarmSecond = null;
            _alarmMessage = null;
        }

        private void SetAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            _alarmHour = HoursComboBox.Text;
            _alarmMinute = MinutesComboBox.Text;
            _alarmSecond = SecondsComboBox.Text;
            _alarmMessage = AlarmMessageTextBox.Text;

            // Скидаємо вибір
            HoursComboBox.SelectedIndex = -1;
            MinutesComboBox.SelectedIndex = -1;
            SecondsComboBox.SelectedIndex = -1;
            AlarmMessageTextBox.Clear();

            MessageBox.Show($"Будильник встановлено на {_alarmHour}:{_alarmMinute}:{_alarmSecond}",
                          "Будильник",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
