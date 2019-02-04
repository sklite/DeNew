using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeNew.Settings
{
    /// <summary>
    /// TODO: перенести всё в json конфииги
    /// </summary>
    public class VariablesSettingsConfig
    {
        public const string MainContentPagePrefix = "main";

        public const int MAIN_PAGE_ID = 1;

        public static int TIME_TO_REDIRECT = 5;

        public const string PREVIEW_IMG_DIR = @"/Images/Preview/";

        public const int ADMIN_ACCESS_LEVEL = 1;

        // глобальные настройки, должны быть во всех страницах

        public const int SELECT_IND = -2;

        public const int ADD_NEW_IND = -1;

        public const string DEFAULT_ARTICLE_NAME = "Впишите сюда название статьи";

        public const string DEFAULT_ARTICLE_DESCRIPTION = "Введите сюда описание статьи, что будет под картинкой";

        public const string DEFAULT_ARTICLE_CONTENT = "Введите сюда текст статьи. ";

        public const bool IS_HOST =
            false;
        // true;

        public static string DbName = IS_HOST ? "Dubna" : "ExpressDal";

        public static string FolderPrefix = IS_HOST ? string.Empty : string.Empty;
    }
}
