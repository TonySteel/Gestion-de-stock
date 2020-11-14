using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.Collections.Generic;
using WcfGestionStock.ClassGestionStock;

namespace WcfGestionStock.Modeles
{
    public class MySQLProviderUtilisateur
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["connectSQL"].ConnectionString;

        #region loguer
        public static bool LoguerUtilisateur(string LoginUtilisateur, string MotDePasse)
        {
            DataTable TableUtilisateur = new DataTable();

            bool ValidationConnection = false;
            using (MySqlConnection cn = new MySqlConnection(_cs))
            {
                try
                {
                    string decmotdepasse;
                    MySqlDataAdapter sdb = new MySqlDataAdapter("select motDePasse from utilisateur where login = '" + LoginUtilisateur + "'", cn);
                    sdb.Fill(TableUtilisateur);
                    //  Décryptage 
                    string motdepasse = TableUtilisateur.Rows[0][0].ToString();
                    /*byte[] protectedBytes = Convert.FromBase64String(motdepasse);
                    byte[] bytes = ProtectedData.Unprotect(protectedBytes, null, DataProtectionScope.CurrentUser);
                    decmotdepasse = Encoding.UTF8.GetString(bytes);*/

                    if (MotDePasse == motdepasse)
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from utilisateur where login = '" + LoginUtilisateur + "' and motDePasse = '" + motdepasse + "'", cn);
                        sda.Fill(TableUtilisateur);

                        if (TableUtilisateur.Rows[1][1].ToString() == "1")
                        {
                            //MessageBox.Show("Vous êtes conneté !");                     
                            ValidationConnection = true;
                        }
                        else
                        {
                            //MessageBox.Show("La connection a échouée !");
                            ValidationConnection = false;
                        }
                    }
                    else
                    {
                        //MessageBox.Show("La connection a échouée !");
                        ValidationConnection = false;
                    }
                }
                catch (Exception)
                {
                    return ValidationConnection;
                }
            }
            return ValidationConnection;
        }
        #endregion

        #region Lire Table Utilisateur Sql
        public static List<ClsUtilisateur> LuTableUtilisateurSql(string _RequeteSql)
        {
            List<ClsUtilisateur> cliste = new List<ClsUtilisateur>();
            using (MySqlConnection cn = new MySqlConnection(_cs))
            {
                try
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(_RequeteSql, cn))
                    {
                        MySqlDataReader rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                ClsUtilisateur lg = new ClsUtilisateur();
                                if (_RequeteSql == "select distinct service from utilisateur where id_statut = 2")
                                {
                                    lg.Service = rd.GetString(rd.GetOrdinal("service"));
                                }
                                else
                                {                                    
                                    lg.Id = rd.GetInt32(rd.GetOrdinal("id"));
                                    lg.Login = rd.GetString(rd.GetOrdinal("login"));
                                    lg.MotDePasse = rd.GetString(rd.GetOrdinal("motDePasse"));
                                    lg.Nom = rd.GetString(rd.GetOrdinal("nom"));
                                    lg.Prenom = rd.GetString(rd.GetOrdinal("prenom"));
                                    lg.Mail = rd.GetString(rd.GetOrdinal("mail"));
                                    lg.Id_Statut = rd.GetInt32(rd.GetOrdinal("id_statut"));
                                    lg.Societe = rd.GetString(rd.GetOrdinal("societe"));
                                    lg.Service = rd.GetString(rd.GetOrdinal("service"));
                                }
                                cliste.Add(lg);
                            }
                        }
                        rd.Close();
                    }
                    cn.Close();
                }
                catch (MySqlException)
                {
                    
                }
            }
            return cliste;
        }
        #endregion

        #region Ajouter Supprimer Modifier Utilisateur Sql
        public static void AjoutSupModifUtilisateurSql(string _RequeteSql)
        {
            using (MySqlConnection cn = new MySqlConnection(_cs))
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand(_RequeteSql, cn))
                {
                    try
                    {
                        MySqlDataReader rd = cmd.ExecuteReader();
                        rd.Close();
                    }
                    catch { }
                }
                cn.Close();
            }
        }
        #endregion
    }
}
