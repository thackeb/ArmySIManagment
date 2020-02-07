using ArmySIManagment.BuisnessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmySIManagment.BuisnessLogic.Models.SensitiveItems
{
    public class SensitiveItemBaseClass : BaseModel
    {
        private double _serialNumber;
        private string _rosterNumber;
        private string _equipmentName;

        private int _siId;

        public int SiIndex
        {
            get
            {
                return _siId;
            }
            set
            {
                SetProperty(ref _siId, value);
            }
        }

        public double SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                SetProperty(ref _serialNumber, value);
            }
        }
        public string RosterNumber
        {
            get
            {
                return _rosterNumber;
            }
            set
            {
                SetProperty(ref _rosterNumber, value);
            }
        }

        public string EquipmentName
        {
            get
            {
                return _equipmentName;
            }
            set
            {
                SetProperty(ref _equipmentName, value);
            }
        }
    }
}
