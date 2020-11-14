using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using WcfGestionStock.ClassGestionStock;
using System.Collections.Generic;

namespace WcfGestionStock.Modeles
{
    public class MySQLProviderCmdFournisseur
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["connectSQL"].ConnectionString;

        #region Lire Commande Fournisseur Sql
        public static List<ClsCmdFournisseur> LuCmdFournisseurSql(string _RequeteSql)
        {
            List<ClsCmdFournisseur> cliste = new List<ClsCmdFournisseur>();
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
                            ClsCmdFournisseur lg = new ClsCmdFournisseur();
                            try
                            {
                                lg.Id = rd.GetInt32(rd.GetOrdinal("id"));
                                lg.Id_fournisseur = rd.GetInt32(rd.GetOrdinal("id_fournisseur"));
                                try
                                {
                                    if (!rd.IsDBNull(rd.GetOrdinal("societe")))
                                        lg.Societe = rd.GetString(rd.GetOrdinal("societe"));
                                }
                                catch { }

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
                                lg.Prix_unitaire = rd.GetDecimal(rd.GetOrdinal("prix_unitaire"));
                                lg.Quantite = rd.GetInt32(rd.GetOrdinal("quantite"));                                
                                lg.Date_cmd = rd.GetDateTime(rd.GetOrdinal("date_cmd"));
                                if (!rd.IsDBNull(rd.GetOrdinal("date_reception")))
                                    lg.Date_reception = rd.GetDateTime(rd.GetOrdinal("date_reception"));
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

        #region Lire Somme des cmd Sql
        public static List<ClsCmdFournisseur> ResultatSommeCmdFournisseurSql(string _RequeteSql)
        {
            List<ClsCmdFournisseur> cliste = new List<ClsCmdFournisseur>();
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
                            ClsCmdFournisseur lg = new ClsCmdFournisseur();
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

        #region Ajouter Commande Fournisseur Sql
        public static void RetourAjoutSupModifCmdFournisseurSql(string _RequeteSql)
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
