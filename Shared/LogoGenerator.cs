using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Shared
{
    public class LogoGenerator
    {
        public static string GeneratorLogo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("_________                   _______  _______           _______ ");
            sb.AppendLine("\\__   __/|\\     /||\\     /|(  ____ )(  ____ \\|\\     /|(  ____ \\");
            sb.AppendLine("   ) (   | )   ( |( \\   / )| (    )|| (    \\/| )   ( || (    \\/");
            sb.AppendLine("   | |   | (___) | \\ (_) / | (____)|| (_____ | |   | || (_____ ");
            sb.AppendLine("   | |   |  ___  |  \\   /  |     __)(_____  )| |   | |(_____  )");
            sb.AppendLine("   | |   | (   ) |   ) (   | (\\ (         ) || |   | |      ) |");
            sb.AppendLine("   | |   | )   ( |   | |   | ) \\ \\__/\\____) || (___) |/\\____) |");
            sb.AppendLine("   )_(   |/     \\|   \\_/   |/   \\__/\\_______)(_______)\\_______)");
            sb.AppendLine("                                                               ");
            return sb.ToString();
        }
    }
}
