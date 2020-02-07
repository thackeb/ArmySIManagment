using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace ArmySIManagment.BuisnessLogic.Models
{
    public class ArmyDrillSheet:BaseModel
    {
        private DateTime _drillDate = new DateTime();
        private List<Soldier> _soldierAttended;
        private SensitiveItemList _siItems;
        private Dictionary<Soldier, SensitiveItemList> _siRoster;
        private ArmySIExcelSheet _armySIWorksheet;
        private string _excelTableName;

        public Dictionary<int, string> Columns = new Dictionary<int, string>
        {
            { 1,"Position" },
            { 2,"LastName" },
            { 3,"MainBody" },
            { 4,"Advon" },
            { 5,"Rear" },


        };

        public ArmyDrillSheet (ref ArmySIExcelSheet  armySIExcelSheet)
        {
            _soldierAttended = new List<Soldier>();
            _armySIWorksheet = armySIExcelSheet;
            _siItems = new SensitiveItemList();
            _siRoster = new Dictionary<Soldier, SensitiveItemList>();
            _drillDate = new DateTime();
            _excelTableName = "ArmySIRoster";


        }
        public List<Soldier> SoldierAttended
        {
            get
            {
                return _soldierAttended;
            }
            set
            {
                SetProperty(ref _soldierAttended, value);
            }
        }
        public SensitiveItemList SIItems
        {
            get
            {
                return _siItems;
            }
            set
            {
                SetProperty(ref _siItems, value);
            }
        }
        public Dictionary<Soldier, SensitiveItemList>  SIRoster
        {
            get
            {
                return _siRoster;
            }
            set
            {
                SetProperty(ref _siRoster, value);
            }
        }
        public string ExcelTableName
        {
            get
            {
                return _excelTableName;
            }
            set
            {
                SetProperty(ref _excelTableName, value);
            }
        }

        public int SaveDrillSIRoster ()
        {
            //New Sheet to Save Drill SI Roster
            _drillDate = DateTime.Now;
            string sheetName = "DrillSIRoster" ;
            sheetName.Concat(_drillDate.ToString());
            Worksheet newSheet = _armySIWorksheet.ExcelWorkbook.Worksheets.Add();
            ListObject newTable =  newSheet.ListObjects.AddEx();
            newTable.Name = _excelTableName;
            newSheet.Name = sheetName;

            //Time To setup the Columns in New Table



            _armySIWorksheet.ExcelWorkbook.Save();




            return 1;
        }
    }
}
