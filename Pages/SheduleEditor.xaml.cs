using Newtonsoft.Json;
using System.IO;
using Belly.Objects;
using System.Windows.Controls;
using System.Collections.Generic;
using Belly.Classes.StaticClasses;
using System.Windows;
using Belly.Dialogs;

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

            schedules.SelectedIndex = 0;
        }

        private void schedules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataListSchedule.ItemsSource = ((Schedule)schedules.SelectedItem).bells;
        }

        private void CreateBell(object sender, System.Windows.RoutedEventArgs e)
        {

            List<Bell> tempList = dataListSchedule.ItemsSource as List<Bell>;
            tempList.Add(new Bell("Звонок", "8:30", musicLists.Folder5Min[0]));
            dataListSchedule.ItemsSource = null;
            dataListSchedule.ItemsSource = tempList;


        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            List<Schedule> schedulesList = schedules.ItemsSource as List<Schedule>;

            var jsonWrite = JsonConvert.SerializeObject(schedulesList, Formatting.Indented);

            File.WriteAllText("sheduleList.json", jsonWrite);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ChangeBellData changeBellData = new ChangeBellData();

            if (changeBellData.ShowDialog() == true)
            {

            }
        }
    }
}
