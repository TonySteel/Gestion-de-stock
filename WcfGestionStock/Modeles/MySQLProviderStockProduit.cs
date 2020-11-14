using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using WcfGestionStock.ClassGestionStock;

namespace WcfGestionStock.Modeles
{
    public class MySQLProviderStockProduit
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["connectSQL"].ConnectionString;

        #region Lire Stock Produit Sql
        public static List<ClsStockProduit> LuStockProduitSql(string _RequeteSql)
        {
            List<ClsStockProduit> cliste = new List<ClsStockProduit>();
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
                            ClsStockProduit lg = new ClsStockProduit();
                            try
                            {
                                lg.Id = rd.GetInt32(rd.GetOrdinal("id"));
                                lg.Nom_Produit = rd.GetString(rd.GetOrdinal("nom_produit"));
                                lg.Description = rd.GetString(rd.GetOrdinal("description"));
                                lg.Prix_Vente = rd.GetDecimal(rd.GetOrdinal("prix_vente"));
                                lg.Quantite_Stock = rd.GetInt32(rd.GetOrdinal("quantite_stock"));
                                lg.Id_Categorie = rd.GetInt32(rd.GetOrdinal("id_categorie"));
                                lg.Id_Fournisseur = rd.GetInt32(rd.GetOrdinal("id_fournisseur"));
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

        #region Lire Somme des articles Sql
        public static List<ClsStockProduit> ResultatSommeProduitSql(string _RequeteSql)
        {
            List<ClsStockProduit> cliste = new List<ClsStockProduit>();
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
                            ClsStockProduit lg = new ClsStockProduit();
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

        #region Lire categorie articles Sql
        public static List<ClsStockProduit> LuCategorieSql(string _RequeteSql)
        {
            List<ClsStockProduit> cliste = new List<ClsStockProduit>();
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
                            ClsStockProduit lg = new ClsStockProduit();
                            try
                            {
                                lg.Id = rd.GetInt32(rd.GetOrdinal("id"));
                                lg.Nom_Categorie = rd.GetString(rd.GetOrdinal("nom_categorie"));
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

        #region Ajouter Supprimer Modifier Produit Sql
        public static void AjoutSupModifProduitSql(string _RequeteSql)
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