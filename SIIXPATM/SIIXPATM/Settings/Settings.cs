using SIIXPATM.Modelos;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIIXPATM.Settings
{
    class Settings
    {
        private static ISettings AppSettings =>
            CrossSettings.Current;

        public static string host
        {
            get => AppSettings.GetValueOrDefault(nameof(host), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(host), value);
        }


        public static string email
        {
            get => AppSettings.GetValueOrDefault(nameof(email), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(email), value);
        }

        public static string nocont
        {
            get => AppSettings.GetValueOrDefault(nameof(nocont), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(nocont), value);
        }
        public static string AlumnoName
        {
            get => AppSettings.GetValueOrDefault(nameof(AlumnoName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AlumnoName), value);
        }
        public static string MaestroName
        {
            get => AppSettings.GetValueOrDefault(nameof(MaestroName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(MaestroName), value);
        }
        public static string MateriaName
        {
            get => AppSettings.GetValueOrDefault(nameof(MateriaName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(MateriaName), value);
        }


        public static string AlumnoEmail
        {
            get => AppSettings.GetValueOrDefault(nameof(AlumnoEmail), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AlumnoEmail), value);
        }
        public static string MaestroEmail
        {
            get => AppSettings.GetValueOrDefault(nameof(MaestroEmail), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(MaestroEmail), value);
        }



        public static string cvemaes
        {
            get => AppSettings.GetValueOrDefault(nameof(cvemae), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(cvemae), value);
        }


        public static string rol
        {
            get => AppSettings.GetValueOrDefault(nameof(rol), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(rol), value);
        }



        public static String token
        {
            get => AppSettings.GetValueOrDefault(nameof(token), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(token), value);
        }
        public static String cvemat
        {
            get => AppSettings.GetValueOrDefault(nameof(cvemat), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(cvemat), value);
        }
        public static String nogpo
        {
            get => AppSettings.GetValueOrDefault(nameof(nogpo), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(nogpo), value);
        }
        public static String cvemae
        {
            get => AppSettings.GetValueOrDefault(nameof(cvemae), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(cvemae), value);
        }

        public static String salon
        {
            get => AppSettings.GetValueOrDefault(nameof(salon), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(salon), value);
        }
        public static String horario
        {
            get => AppSettings.GetValueOrDefault(nameof(horario), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(horario), value);
        }
       
    }
}
