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
    public class MySQLProviderFournisseur
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["connectSQL"].ConnectionString;

        #region Lire Fournisseur Sql
        public static List<ClsFournisseur> LuFournisseurSql(string _RequeteSql)
        {
            List<ClsFournisseur> cliste = new List<ClsFournisseur>();
            using (MySqlConnection cn = new MySqlConnection(_cs))
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand(_RequeteSql, cn))
                {
                    MySqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            ClsFournisseur lg = new ClsFournisseur();
                            try
                            {
                                lg.Id = rd.GetInt32(rd.GetOrdinal("id"));                                
                                lg.Societe = rd.GetString(rd.GetOrdinal("societe"));
                                lg.Mail = rd.GetString(rd.GetOrdinal("mail"));                                
                            }
                            catch (Exception)
                            {

                            }
                            cliste.Add(lg);
                        }
                    }
                    rd.Close();
                }
                cn.Close();
            }
            return cliste;
        }
        #endregion

        #region Ajouter Fournisseur Sql
        public static void RetourAjoutSupModifFournisseurSql(string _RequeteSql)
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
