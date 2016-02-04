using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Library
{
        public struct EmailResult
        {
            public bool Result;
            public string ErrorMsg;

        }

        public struct CheckBalanceResult
        {
            public bool Result;
            public string EmailMsg;
            public string SMSMessage;

        }

        public class ConfigSettings
        {
            public static readonly string SQL20000 = "SQL2000";
            public static readonly string SQL2005 = "SQL2005";

            private static SqlConnection _DBConn = null;
            private static SqlConnection _DBConnTransactions = null;
            private static SqlConnection _CampusDishDBConn = null;

            private static SqlCommand _DBCmd = null;
            private static SqlCommand _DBCmdTransactions = null;
            private static SqlCommand _CampusDishDBCmd = null;


            public static string LiveTileURL
            {
                get
                {
                    return ConfigurationManager.AppSettings["LiveTileURL"];
                }
            }

            public static string ImageURL
            {
                get
                {
                    return ConfigurationManager.AppSettings["ImageURL"];
                }
            }

            public static string SMTPServer
            {
                get
                {
                    return ConfigurationManager.AppSettings["SMTPServer"];
                }
            }
            public static string SmtpServerUserName
            {
                get
                {
                    return ConfigurationManager.AppSettings["AuthUserName"];
                }
            }
            public static string SmtpServerPassword
            {
                get
                {
                    return ConfigurationManager.AppSettings["AuthPassword"];
                }
            }
            public static string EmailFrom
            {
                get
                {
                    return ConfigurationManager.AppSettings["EmailFrom"];
                }
            }
            public static string AuthUserName
            {
                get
                {
                    return ConfigurationManager.AppSettings["AuthUserName"];
                }
            }
            public static string AuthPassword
            {
                get
                {
                    return ConfigurationManager.AppSettings["AuthPassword"];
                }
            }


            public static string ActFas_WS
            {
                get
                {
                    return ConfigurationManager.AppSettings["ActFas_WS"];
                }
            }

            public static string ActFasMultiLineItems_WS
            {
                get
                {
                    return ConfigurationManager.AppSettings["ActFasMultiLineItems_WS"];
                }
            }
            public static string Actfas_timeout
            {
                get
                {
                    return ConfigurationManager.AppSettings["Actfas_timeout"];
                }
            }
            public static string SQLVersion
            {
                get
                {
                    return ConfigurationManager.AppSettings["SQLVersion"];
                }
            }
            public static string RemovePatronLink
            {
                get
                {
                    return ConfigurationManager.AppSettings["RemovePatronLink"];
                }
            }
            public static string CampusDishExtendedConnectionString
            {
                get
                {
                    return ConfigurationManager.AppSettings["CampusDishExtended"];
                }
            }

            public static string DBConnectionCorrectionsORSString
            {
                get
                {
                    return ConfigurationManager.AppSettings["connectionString"];
                }
            }
            public static string DBConnectionCampusDishTransactions
            {
                get
                {
                    return ConfigurationManager.AppSettings["CampusDishTransactions"];
                }
            }
            public static string AttachmentPath
            {
                get
                {
                    return ConfigurationManager.AppSettings["AttachmentPath"];
                }
            }

            public static string Development
            {
                get
                {
                    return ConfigurationManager.AppSettings["Development"];
                }
            }

            public static string SMSDevelopment
            {
                get
                {
                    return ConfigurationManager.AppSettings["SMSDevelopment"];
                }
            }
            public static string WriteLogFile
            {
                get
                {
                    return ConfigurationManager.AppSettings["WriteLogfile"];
                }
            }
            public static string LogFile
            {
                get
                {
                    return ConfigurationManager.AppSettings["Logfile"];
                }
            }
            public static string UseProxy
            {
                get
                {
                    return ConfigurationManager.AppSettings["UseProxy"];
                }
            }
            public static string ProxyName
            {
                get
                {
                    return ConfigurationManager.AppSettings["ProxyName"];
                }
            }

            public static string ProxyDomain
            {
                get
                {
                    return ConfigurationManager.AppSettings["ProxyDomain"];
                }
            }
            public static string ProxyUser
            {
                get
                {
                    return ConfigurationManager.AppSettings["ProxyUser"];
                }
            }
            public static string ProxyPassword
            {
                get
                {
                    return ConfigurationManager.AppSettings["ProxyPassword"];
                }
            }


            public static string EmailSuccessfulOrdersTo
            {
                get
                {
                    return ConfigurationManager.AppSettings["EmailSuccessfulOrdersTo"];
                }
            }
            public static string EmailTo
            {
                get
                {
                    return ConfigurationManager.AppSettings["EmailTo"];
                }
            }
            public static string EmailCC
            {
                get
                {
                    return ConfigurationManager.AppSettings["EmailCC"];
                }
            }


            public static string InmateFileSource
            {
                get
                {
                    return ConfigurationManager.AppSettings["InmateFileSource"];
                }
            }
            public static string InmateFileProcessed
            {
                get
                {
                    return ConfigurationManager.AppSettings["InmateFileProcessed"];
                }
            }
            public static string InmateFileArchived
            {
                get
                {
                    return ConfigurationManager.AppSettings["InmateFileArchived"];
                }
            }
            //

            public static SqlCommand CampusDishDBCmd
            {
                get
                {
                    if (_CampusDishDBCmd == null)
                    {
                        _CampusDishDBCmd = new SqlCommand();
                        _CampusDishDBCmd.Connection = CampusDishDBConn;
                    }
                    return _CampusDishDBCmd;
                }
            }

            public static SqlCommand DBCmd
            {
                get
                {
                    if (_DBCmd == null)
                    {
                        _DBCmd = new SqlCommand();
                        _DBCmd.Connection = DBConn;
                    }
                    return _DBCmd;
                }
            }
            public static SqlCommand DBCmdTransactions
            {
                get
                {
                    if (_DBCmdTransactions == null)
                    {
                        _DBCmdTransactions = new SqlCommand();
                        _DBCmdTransactions.Connection = DBConnTransactions;
                    }
                    return _DBCmdTransactions;
                }
            }
            public static SqlConnection CampusDishDBConn
            {
                get
                {
                    if ((_CampusDishDBConn == null) || (_CampusDishDBConn.State != ConnectionState.Open))
                    {
                        _CampusDishDBConn = new SqlConnection(CampusDishExtendedConnectionString);
                        _CampusDishDBConn.Open();
                    }

                    return _CampusDishDBConn;
                }
            }
            public static SqlConnection DBConn
            {
                get
                {
                    if ((_DBConn == null) || (_DBConn.State != ConnectionState.Open))
                    {
                        _DBConn = new SqlConnection(DBConnectionCorrectionsORSString);
                        _DBConn.Open();
                    }

                    return _DBConn;
                }
            }
            public static SqlConnection DBConnTransactions
            {
                get
                {
                    if ((_DBConnTransactions == null) || (_DBConnTransactions.State != ConnectionState.Open))
                    {
                        _DBConnTransactions = new SqlConnection(DBConnectionCampusDishTransactions);
                        _DBConnTransactions.Open();
                    }

                    return _DBConnTransactions;
                }
            }
            //public static string EncryptString(string encrytText)
            //{
            //    string K1 = "g9f9tr4j34t66lkjgovjo8rs";
            //    string K2 = "vgv8gfd9";
            //    ETech.Security.Crypto.Encrypt CryptoClass = new ETech.Security.Crypto.Encrypt(K1, K2);
            //    if (SQLVersion == ConfigSettings.SQL20000)
            //        return CryptoClass.EncryptString(encrytText);
            //    else
            //        return encrytText;
            //}
            //public static string DecryptString(string encrytText)
            //{
            //    string K1 = "g9f9tr4j34t66lkjgovjo8rs";
            //    string K2 = "vgv8gfd9";
            //    ETech.Security.Crypto.Encrypt CryptoClass = new ETech.Security.Crypto.Encrypt(K1, K2);
            //    if (SQLVersion == ConfigSettings.SQL20000)
            //        return CryptoClass.DecryptString(encrytText);
            //    else
            //        return encrytText;
            //}

        }

}
