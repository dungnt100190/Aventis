using Kiss.Infrastructure.Selectable;
using Kiss.Model.DTO.Fa;

namespace Kiss.Spielwiese
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            //Items = new SelectableList<XLOVCode>
            //{
            //    new SelectableItem<XLOVCode>(new XLOVCode{LOVName = "LOV",Text = "123"}, true),
            //    new SelectableItem<XLOVCode>(new XLOVCode{LOVName = "LOV",Text = "456"}, false),
            //    new SelectableItem<XLOVCode>(new XLOVCode{LOVName = "LOV",Text = "789"}, true),
            //};
            Items = new SelectableList<FaZeitachseDTOType>
            {
                FaZeitachseDTOType.Kategorie,
                FaZeitachseDTOType.PendenzenOffen,
                FaZeitachseDTOType.Ziele
            };
        }


        public SelectableList<FaZeitachseDTOType> Items
        {
            get;
            set;
        }

    }
}