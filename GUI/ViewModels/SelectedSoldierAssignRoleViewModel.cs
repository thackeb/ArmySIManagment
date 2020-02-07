using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.Connectors;
using Caliburn.Micro;
namespace ArmySIManagment.GUI.ViewModels
{
    public class SelectedSoldierAssignRoleViewModel: Conductor<Screen>.Collection.AllActive
    {
        private Soldier _soldier;
        private List<RoleAssignments> _roleAssignments;
        private Roles _selectedRole;
        private BindableCollection<Roles> _bindRoles;

        public BindableCollection<Roles> BindRoles
        {
            get
            {
                return _bindRoles;
            }
            set
            {
                _bindRoles = value;
                NotifyOfPropertyChange(() => BindRoles);
            }
        }

        public Roles SelectedRole
        {
            get
            {
                return _selectedRole;
            }
            set
            {
                _selectedRole = value;
                NotifyOfPropertyChange(() => SelectedRole);
            }
        }

        public List<RoleAssignments> RoleAssignments
        {
            get
            {
                return _roleAssignments;
            }
            set
            {
                _roleAssignments = value;
                NotifyOfPropertyChange(() => RoleAssignments);
                
            }
        }

        public Soldier Soldier
        {
            get
            {
                return _soldier;
            }
            set
            {
                _soldier = value;
                NotifyOfPropertyChange(() => Soldier);
            }
        }

        public SelectedSoldierAssignRoleViewModel(string platoon, List<RoleAssignments> roleAssignments, Soldier soldier, List<Roles> roles)
        {
            DisplayName = platoon;
            RoleAssignments = roleAssignments;
            BindRoles = new BindableCollection<Roles>();
            foreach (Roles roles1 in roles)
            {
                bool alreadyAssigned = false;
                foreach (RoleAssignments roleAssignments2 in roleAssignments)
                {
                    if(roleAssignments2.Role == roles1)
                    {
                        alreadyAssigned = true;
                        break;
                    }
                }
                if(!alreadyAssigned)
                {
                    BindRoles.Add(roles1);
                }
            }
          
            Soldier = soldier;
            foreach(RoleAssignments roleAssignments1 in roleAssignments)
            {
                if (roleAssignments1.AssignedSoldier == Soldier)
                {
                    SelectedRole = roleAssignments1.Role;
                    break;
                }
            }
            if(RoleAssignments == null)
            {
                SelectedRole = new Roles();
            }
        }
        public void AssignRoleBtn()
        {
           
           foreach(RoleAssignments roleAssignments in RoleAssignments)
            {
                if(roleAssignments.AssignedSoldier == Soldier)
                {
                    RoleAssignments.Remove(roleAssignments);
                    break;
                }
            }
            RoleAssignments newRoleAssignment = new RoleAssignments();
            newRoleAssignment.AssignedSoldier = Soldier;
            newRoleAssignment.Role = SelectedRole;
            RoleAssignments.Add(newRoleAssignment);
            ArmyDataBaseConnector.SaveRoleAssignments(newRoleAssignment);
            this.TryClose();
        }
    }
}
