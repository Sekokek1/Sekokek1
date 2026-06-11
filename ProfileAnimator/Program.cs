using System;
using System.Globalization;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
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

        File.WriteAllText("../animated-console.svg", consoleSvg, Encoding.UTF8);

     
        DateTime now = DateTime.UtcNow;

        string dayOfWeek = now.ToString("dddd", CultureInfo.InvariantCulture).ToUpper();
        string day = now.ToString("dd", CultureInfo.InvariantCulture);
        string month = now.ToString("MMMM", CultureInfo.InvariantCulture).ToUpper();

        string pacmanSvg = $@"<svg width='800' height='200' xmlns='http://www.w3.org/2000/svg'>
            <style>
                .pacman-group {{ animation: move 6s linear infinite; }}
                .mouth {{ animation: chomp 0.3s infinite alternate; transform-origin: 0px 0px; }}
                .date-text {{ font-family: 'Segoe UI', Arial, sans-serif; font-size: 16px; font-weight: bold; fill: #39D353; }}
                
                @keyframes move {{
                    0% {{ transform: translateX(30px); }}
                    100% {{ transform: translateX(770px); }}
                }}
                @keyframes chomp {{
                    0% {{ transform: scaleY(0.1); }}
                    100% {{ transform: scaleY(1); }}
                }}
                
                .item1 {{ animation: hide1 6s infinite; }}
                .item2 {{ animation: hide2 6s infinite; }}
                .item3 {{ animation: hide3 6s infinite; }}
                
                @keyframes hide1 {{ 0%, 23% {{ opacity: 1; }} 24%, 100% {{ opacity: 0; }} }}
                @keyframes hide2 {{ 0%, 49% {{ opacity: 1; }} 50%, 100% {{ opacity: 0; }} }}
                @keyframes hide3 {{ 0%, 76% {{ opacity: 1; }} 77%, 100% {{ opacity: 0; }} }}
            </style>
            
            <rect width='100%' height='100%' fill='#0D1117' rx='10' />
            <text x='20' y='30' fill='#8B949E' font-family='Arial' font-size='14'>Alexander's Daily Date Eater</text>
            
            <text x='200' y='105' class='date-text item1' text-anchor='middle'>{dayOfWeek}</text>
            <text x='400' y='105' class='date-text item2' text-anchor='middle'>{day}</text>
            <text x='600' y='105' class='date-text item3' text-anchor='middle'>{month}</text>
            
            <g class='pacman-group' transform='translate(0, 100)'>
                <circle cx='0' cy='0' r='20' fill='#E3B341' />
                <polygon points='0,0 25,-20 25,20' fill='#0D1117' class='mouth' />
            </g>
        </svg>";

        File.WriteAllText("../pacman.svg", pacmanSvg, Encoding.UTF8);
    }
}