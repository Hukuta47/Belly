using Newtonsoft.Json;
using System.IO;
using Belly.Objects;
using System.Windows.Controls;
using System.Collections.Generic;

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
            var jsonRead = JsonConvert.DeserializeObject<List<Schedule>>(File.ReadAllText("sheduleList"));
            schedules.ItemsSource = jsonRead;


        }

    }
}
