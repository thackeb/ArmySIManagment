using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;


namespace ArmySIManagment.Connectors
{
    public class ArmyDataBaseConnector
    {
        public static string ConfigurationManage { get; private set; }

   
        public static void SaveSoldierInfo (Soldier soldier)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", soldier.FirstName);
                parameters.Add("@LastName", soldier.LastName);
                parameters.Add("@Rank", soldier.Rank);
                parameters.Add("@Status", soldier.Status);
                if (soldier.SoldierID == -1)
                {
                    cnn.Execute("insert into SoldierRoster (FirstName,LastName,Rank,Status) values (@FirstName,@LastName,@Rank,@Status) ", parameters);
                }
                else
                {
                    parameters.Add("@SoldierID", soldier.SoldierID);
                    cnn.Execute("update  SoldierRoster  SET FirstName =  @FirstName, LastName =  @LastName, Rank = @Rank, Status = @Status  Where SoldierID == @SoldierID  ", parameters);
                }

            }
        }


      

        public static List<Soldier> LoadSoldierInfo ()
        {
       
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Soldier>("select * from SoldierRoster", new DynamicParameters());
              
                   
                  
                return output.ToList();
            }
        }

        public static void RemoveSoldierInfo(Soldier soldier)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SoldierID", soldier.SoldierID);
                cnn.Execute("delete from SoldierRoster where SoldierID = @SoldierID ", parameters);
            }
        }
        public static void SaveSensitiveItem(SensitiveItemBaseClass sensitiveItem)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EquipmentName", sensitiveItem.EquipmentName);
                parameters.Add("@SerialNumber", sensitiveItem.SerialNumber);
                parameters.Add("@RosterNumber", sensitiveItem.RosterNumber);
                var output = cnn.Query<SensitiveItemBaseClass>("select * from SensitiveItems where EquipmentName == @EquipmentName AND SerialNumber == @SerialNumber AND RosterNumber = @RosterNumber", parameters);
                List<SensitiveItemBaseClass> tmp = output.ToList();

                if (tmp.Count == 0)
                    cnn.Execute("insert into SensitiveItems (EquipmentName,SerialNumber,RosterNumber) values (@EquipmentName,@SerialNumber,@RosterNumber) ", parameters);

            }
        }

        public static List<SensitiveItemBaseClass> LoadSensitiveItemList()
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SensitiveItemBaseClass>("select * from SensitiveItems", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void RemoveSensitiveItem(SensitiveItemBaseClass sensitiveItem)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SiIndex", sensitiveItem.SiIndex);
                cnn.Execute("delete from SensitiveItems where SiIndex = @SiIndex", parameters);
            }
        }

        public static int SaveRole(Roles newRole)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Platoon", newRole.Platoon);
                parameters.Add("@RoleName", newRole.RoleName);
                parameters.Add("@Squad", newRole.Squad);
                parameters.Add("@FireTeam", newRole.FireTeam);
                var output = cnn.Query<Roles>("select * from Roles where  Platoon == @Platoon AND RoleName = @RoleName AND Squad = @Squad AND FireTeam=@FireTeam", parameters);
                List<Roles> tmp = output.ToList();

                if (tmp.Count == 0)
                    cnn.Execute("insert into Roles (Platoon,RoleName,Squad,FireTeam) values (@Platoon,@RoleName,@Squad,@FireTeam) ", parameters);

                output = cnn.Query<Roles>("select * from Roles where  Platoon == @Platoon AND RoleName = @RoleName AND Squad = @Squad AND FireTeam=@FireTeam", parameters);
                tmp = output.ToList();
                return tmp[0].RoleID;

            }
        }

        public static List<Roles> LoadRoles()
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Roles>("select * from Roles", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void RemoveRole(Roles role)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RoleID", role.RoleID);

                cnn.Execute("Delete from Roles where RoleID = @RoleID", parameters);
            }
        }


        public static void SaveRoleAssignments(RoleAssignments newRoleAssignmet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                DynamicParameters parameters = new DynamicParameters();
                if (newRoleAssignmet.AssignedSoldier.SoldierID == -1)
                {
                    DynamicParameters soldQ = new DynamicParameters();
                    soldQ.Add("@LastName", newRoleAssignmet.AssignedSoldier.LastName);
                    soldQ.Add("@FirstName", newRoleAssignmet.AssignedSoldier.FirstName);
                    var soldierId = cnn.Query<int>("select SoldierID from SoldierRoster  where LastName == @LastName AND FirstName == @FirstName ", soldQ);
                    newRoleAssignmet.AssignedSoldier.SoldierID = Convert.ToInt32(soldierId.First());
                }
                parameters.Add("@SoldierID", newRoleAssignmet.AssignedSoldier.SoldierID);
                parameters.Add("@RoleID", newRoleAssignmet.Role.RoleID);
                
                var output = cnn.Query<RoleAssignments>("select * from RoleAssignments where  SoldierID == @SoldierID AND RoleID = @RoleID ", parameters);
                List<RoleAssignments> tmp = output.ToList();

                if (tmp.Count == 0)
                    cnn.Execute("insert into RoleAssignments (SoldierID,RoleID) values (@SoldierID,@RoleID) ", parameters);
            }
        }



        public static List<RoleAssignments> LoadRoleAssignments(List<Soldier> soldiers, List<Roles> roles)
        {
            
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<RoleAssignments> roleAssignments = new List<RoleAssignments>();
                var outputSoldier = cnn.Query<(int,int)>("select * from RoleAssignments", new DynamicParameters());
                foreach((int,int)assignedRole in outputSoldier )
                {
                    int soldierIndex = 0;
                    int roleIndex = 0;
                    foreach(Soldier soldier in soldiers)
                    {
                        if (soldier.SoldierID == assignedRole.Item2)
                        {
                            
                            break;
                        }
                        soldierIndex++;
                    }
                    foreach(Roles roles1 in roles)
                    {
                        if(roles1.RoleID == assignedRole.Item1)
                        {
                            break;
                        }
                        roleIndex++;
                    }
                    if (!(soldierIndex >= soldiers.Count()) && !(roleIndex >= roles.Count()))
                        roleAssignments.Add(new RoleAssignments(soldiers[soldierIndex], roles[roleIndex]));
                    
                }
                return roleAssignments.ToList();
            }
            
        }

        

        public static void RemoveRoleAssignments(RoleAssignments newRoleAssignmet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SoldierID", newRoleAssignmet.AssignedSoldier.SoldierID);
                parameters.Add("@RoleID", newRoleAssignmet.Role.RoleID);
                cnn.Execute("delete from RoleAssignments  where SoldierID = @SoldierID AND RoleID = @RoleID", parameters);
            }
        }

        public static void SaveWeaponAssignments(WeaponAssignments newWeaponAssignmet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {


                foreach(SensitiveItemBaseClass si in newWeaponAssignmet.AssignedSI)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@RoleID", newWeaponAssignmet.Role.RoleID);
                    parameters.Add("@SIID", si.SiIndex);
                    var output = cnn.Query<RoleAssignments>("select * from SIAssignments where  SIID == @SIID AND RoleID = @RoleID ", parameters);
                    List<RoleAssignments> tmp = output.ToList();

                    if (tmp.Count == 0)
                        cnn.Execute("insert into SIAssignments (SIID,RoleID) values (@SIID,@RoleID) ", parameters);
                }
               
                
            }
        }
        public static List<WeaponAssignments> LoadWeaponAssignments (List<Roles> roles, List<SensitiveItemBaseClass> siList)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<WeaponAssignments> roleAssignments = new List<WeaponAssignments>();
                var outputSoldier = cnn.Query<(int, int)>("select * from SIAssignments", new DynamicParameters());
                foreach ((int, int) assignedRole in outputSoldier)
                {
                    int siIndex = 0;
                    int roleIndex = 0;
                    foreach (SensitiveItemBaseClass si in siList)
                    {
                        if (si.SiIndex == assignedRole.Item2)
                        {

                            break;
                        }
                        siIndex++;
                    }
                    foreach (Roles roles1 in roles)
                    {
                        if (roles1.RoleID == assignedRole.Item1)
                        {
                            break;
                        }
                        roleIndex++;
                    }

                    roleAssignments.Add(new WeaponAssignments(siList[siIndex], roles[roleIndex]));

                }
                //trying to condense the results into each other this doesnt work
                List<Roles> listOfRoles = new List<Roles>();
                List<WeaponAssignments> condensedWeaponsAssignments = new List<WeaponAssignments>();
                foreach (WeaponAssignments weaponAssignments in roleAssignments)
                {
                    if(!listOfRoles.Contains(weaponAssignments.Role))
                    {
                        listOfRoles.Add(weaponAssignments.Role);
                        condensedWeaponsAssignments.Add(weaponAssignments);
                    }
                    else
                    {
                        foreach(WeaponAssignments weaponAssignments1 in condensedWeaponsAssignments)
                        {
                            if(weaponAssignments1.Role == weaponAssignments.Role)
                            {
                                foreach(SensitiveItemBaseClass si in weaponAssignments.AssignedSI)
                                {
                                    weaponAssignments1.AssignedSI.Add(si);
                                }
                            }
                        }
                    }
                }
             
              
                
                return condensedWeaponsAssignments.ToList();
            }
        }

        public static void RemoveWeaponAssignmnet(WeaponAssignments weaponAssignment, SensitiveItemBaseClass selectedSI)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RoleID", weaponAssignment.Role.RoleID);

                parameters.Add("@SIID", selectedSI.SiIndex);

                cnn.Execute("Delete From SIAssignments where RoleID = @RoleID AND SIID = @SIID", parameters);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
