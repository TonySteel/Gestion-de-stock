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
    public class MySQLProviderCmdClient
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["connectSQL"].ConnectionString;

        #region Lire Commande Client Sql
        public static List<ClsCmdClient> LuCmdClientSql(string _RequeteSql)
        {
            List<ClsCmdClient> cliste = new List<ClsCmdClient>();
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
                            ClsCmdClient lg = new ClsCmdClient();
                            try
                            {                                        
                                // Select * 
                                lg.Id = rd.GetInt32(rd.GetOrdinal("id"));
                                lg.Id_utilisateur = rd.GetInt32(rd.GetOrdinal("id_utilisateur"));
                                lg.Id_produit = rd.GetInt32(rd.GetOrdinal("id_produit"));                                        
                                lg.Prix_unitaire = rd.GetDecimal(rd.GetOrdinal("prix_unitaire"));
                                lg.Quantite = rd.GetInt32(rd.GetOrdinal("quantite"));
                                lg.Prix_quantite = rd.GetDecimal(rd.GetOrdinal("prix_quantite"));
                                try
                                {
                                    if (!rd.IsDBNull(rd.GetOrdinal("nom_produit")))
                                        lg.Nom_produit = rd.GetString(rd.GetOrdinal("nom_produit"));
                                    else
                                        lg.Nom_produit = "-";

                                    if (!rd.IsDBNull(rd.GetOrdinal("description")))
                                        lg.Description = rd.GetString(rd.GetOrdinal("description"));
                                }
                                catch { }

                                lg.Date_cmd = rd.GetDateTime(rd.GetOrdinal("date_cmd"));
                                if (!rd.IsDBNull(rd.GetOrdinal("date_livraison")))                                
                                    lg.Date_livraison = rd.GetDateTime(rd.GetOrdinal("date_livraison")); 
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.StackTrace);
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


        #region Lire Somme des cmd Sql
        public static List<ClsCmdClient> ResultatSommeCmdClientSql(string _RequeteSql)
        {
            List<ClsCmdClient> cliste = new List<ClsCmdClient>();
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
                            ClsCmdClient lg = new ClsCmdClient();
                            try
                            {
                                lg.Somme = rd.GetDecimal(rd.GetOrdinal("somme"));
                            }
                            catch (Exception)
                            {
                                lg.Somme = 0;
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

        #region Ajouter Supprimer Modifier Commande Client Sql
        public static void RetourAjoutSupModifCmdClientSql(string _RequeteSql)
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
