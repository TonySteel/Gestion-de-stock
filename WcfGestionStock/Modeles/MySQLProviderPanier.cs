using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using WcfGestionStock.ClassGestionStock;

namespace WcfGestionStock.Modeles
{
    public class MySQLProviderPanier
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["connectSQL"].ConnectionString;

        #region Lire Table Panier Sql
        public static List<ClsPanier> LuTablePanierSql(string _RequeteSql)
        {
            List<ClsPanier> cliste = new List<ClsPanier>();
            using (MySqlConnection cn = new MySqlConnection(_cs))
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand(_RequeteSql, cn))
                {
                    try
                    {
                        MySqlDataReader rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                ClsPanier lg = new ClsPanier();
                                lg.Id = rd.GetInt32(rd.GetOrdinal("id"));
                                lg.Id_produit = rd.GetInt32(rd.GetOrdinal("id_produit"));
                                try
                                {
                                    if (!rd.IsDBNull(rd.GetOrdinal("nom_produit")))
                                        lg.Nom_produit = rd.GetString(rd.GetOrdinal("nom_produit"));
                                    if (!rd.IsDBNull(rd.GetOrdinal("description")))
                                        lg.Description = rd.GetString(rd.GetOrdinal("description"));
                                }
                                catch { }
                                lg.Quantite = rd.GetInt32(rd.GetOrdinal("quantite"));
                                lg.Prix_Vente = rd.GetDecimal(rd.GetOrdinal("prix_vente"));
                                lg.Id_Client = rd.GetInt32(rd.GetOrdinal("id_client"));
                                lg.Somme = lg.Prix_Vente * lg.Quantite;

                                cliste.Add(lg);
                            }
                        }
                        rd.Close();
                    }
                    catch (Exception )
                    {
                        
                    }
                }
                cn.Close();
            }
            return cliste;
        }
        #endregion

        #region Lire Somme Panier Sql
        public static List<ClsPanier> ResultatSommePanierSql(string _RequeteSql)
        {
            List<ClsPanier> cliste = new List<ClsPanier>();
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
                            ClsPanier lg = new ClsPanier();
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

        #region Ajouter Supprimer Modifier panier
        public static void RetourAjoutSupModifPanierSql(string _RequeteSql)
        {
            List<ClsPanier> cliste = new List<ClsPanier>();
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
