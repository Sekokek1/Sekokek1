using System;
using System.Globalization;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // --- Блок 1: Генерация анимированной консоли (оставляем как есть) ---
        string consoleSvg = @"<svg width='600' height='200' xmlns='http://www.w3.org/2000/svg'>
            <style>
                .text { font-family: 'Courier New', monospace; font-size: 16px; fill: #00FF00; }
                .cursor { animation: blink 1s step-end infinite; }
                @keyframes blink { 50% { opacity: 0; } }
            </style>
            <rect width='100%' height='100%' fill='#0D1117' rx='10' />
            <text x='20' y='40' class='text'>Alexander@Server:~$ ./build_architecture.sh</text>
            <text x='20' y='70' class='text'>Compiling database models... [SUCCESS]</text>
            <text x='20' y='100' class='text'>Deploying EF Core migrations... [SUCCESS]</text>
            <text x='20' y='130' class='text'>System Ready<tspan class='cursor'>_</tspan></text>
        </svg>";

        // --- Блок 2: Генерация Пакмана (ПОЛНОСТЬЮ ИСПРАВЛЕНО) ---
        DateTime now = DateTime.UtcNow; 
        string dayOfWeek = now.ToString("dddd", CultureInfo.InvariantCulture).ToUpper();
        string day = now.ToString("dd", CultureInfo.InvariantCulture);
        string month = now.ToString("MMMM", CultureInfo.InvariantCulture).ToUpper();

        string pacmanSvg = $@"<svg width='800' height='200' xmlns='http://www.w3.org/2000/svg'>
            <style>
                /* НОВАЯ ГАРАНТИРОВАННАЯ АНИМАЦИЯ ДВИЖЕНИЯ */
                /* Мы жестко прописываем Y=112px на протяжении всего пути */
                @keyframes move-eater {{
                    0% {{ transform: translate(30px, 112px); }}
                    100% {{ transform: translate(770px, 112px); }}
                }}

                /* Анимация жевания рта */
                @keyframes mouth-chomp {{
                    0% {{ transform: scaleY(0.1); }}
                    100% {{ transform: scaleY(1); }}
                }}

                /* Анимации исчезновения дат (item1, item2, item3) */
                @keyframes hide-item1 {{ 0%, 23% {{ opacity: 1; }} 24%, 100% {{ opacity: 0; }} }}
                @keyframes hide-item2 {{ 0%, 49% {{ opacity: 1; }} 50%, 100% {{ opacity: 0; }} }}
                @keyframes hide-item3 {{ 0%, 76% {{ opacity: 1; }} 77%, 100% {{ opacity: 0; }} }}

                /* Применяем стили и анимации */
                /* Тело Пакмана анимируется по новой move-eater */
                .pacman-body {{ animation: move-eater 6s linear infinite; }}
                .mouth {{ animation: mouth-chomp 0.3s infinite alternate; transform-origin: 0px 0px; }}

                .date-text {{ font-family: 'Segoe UI', Arial, sans-serif; font-size: 20px; font-weight: bold; fill: #39D353; }}
                .item1 {{ animation: hide-item1 6s infinite; }}
                .item2 {{ animation: hide-item2 6s infinite; }}
                .item3 {{ animation: hide-item3 6s infinite; }}
            </style>
            
            <rect width='100%' height='100%' fill='#0D1117' rx='10' />
            <text x='20' y='30' fill='#8B949E' font-family='Arial' font-size='14'>Alexander's Daily Date Eater</text>
            
            <text x='200' y='112' class='date-text item1' text-anchor='middle'>{dayOfWeek}</text>
            <text x='400' y='112' class='date-text item2' text-anchor='middle'>{day}</text>
            <text x='600' y='112' class='date-text item3' text-anchor='middle'>{month}</text>
            
            <g class='pacman-body'>
                <circle cx='0' cy='0' r='20' fill='#E3B341' />
                <polygon points='0,0 25,-20 25,20' fill='#0D1117' class='mouth' />
            </g>
        </svg>";

        // Сохраняем файлы в текущую директорию (корень репозитория на сервере)
        File.WriteAllText("animated-console.svg", consoleSvg, Encoding.UTF8);
        File.WriteAllText("pacman.svg", pacmanSvg, Encoding.UTF8);
    }
}
