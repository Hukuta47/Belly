using Newtonsoft.Json;
using System.IO;
using Belly.Objects;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using Belly.Dialogs;
using Belly.Classes.StaticClasses;
using NAudio.Mixer;

namespace Belly.Pages
{

    public partial class SheduleEditor : Page
    {
        public SheduleEditor()
        {
            InitializeComponent();

            LoadList();

        }

        void LoadList()
        {
            var jsonRead = JsonConvert.DeserializeObject<List<Schedule>>(File.ReadAllText("sheduleList.json"));
            
            schedules.ItemsSource = jsonRead;

            sheduleList.basicSchedule = jsonRead[0];
            sheduleList.shortSchedule = jsonRead[1];
            sheduleList.exclusiveSchedule = jsonRead[2];

            schedules.SelectedIndex = 0;
        }

        private void schedules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataListSchedule.ItemsSource = ((Schedule)schedules.SelectedItem).bells;
        }

        private void CreateBell(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new IssueWindow("Создать");

            List<Issue> tempList = dataListSchedule.ItemsSource as List<Issue>;
            if (dialog.ShowDialog() == true)
            {
                tempList.Add(new Issue(dialog.Name, dialog.Issue.StartTime, dialog.Issue.EndTime, dialog.Issue.Media));
            }

            dataListSchedule.ItemsSource = tempList;
            dataListSchedule.Items.Refresh();

        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            List<Schedule> schedulesList = schedules.ItemsSource as List<Schedule>;

            var jsonWrite = JsonConvert.SerializeObject(schedulesList, Formatting.Indented);

            File.WriteAllText("sheduleList.json", jsonWrite);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Issue issue = dataListSchedule.SelectedItem as Issue;

            IssueWindow IssueData = new IssueWindow("Сохранить", issue);

            if (IssueData.ShowDialog() == true)
            {
                dataListSchedule.SelectedItem = IssueData;

                List<Issue> bells = (List<Issue>)dataListSchedule.ItemsSource;
                dataListSchedule.ItemsSource = null;
                dataListSchedule.ItemsSource = bells;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            ((List<Issue>)dataListSchedule.ItemsSource).RemoveRange(dataListSchedule.SelectedIndex, dataListSchedule.SelectedItems.Count);

            dataListSchedule.Items.Refresh();



        }
    }
}
