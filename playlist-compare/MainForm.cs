using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace playlist_compare
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridViewMusic.DataSource = _allMusic;
            dataGridViewMusic.CellMouseDown += (sender, e) =>
            {
                if (e.Button.Equals(MouseButtons.Right) && !e.RowIndex.Equals(-1))
                {
                    var menu = new ContextMenuStrip();
                    var music = _allMusic[e.RowIndex];
                    dataGridViewMusic.ClearSelection();
                    dataGridViewMusic.Rows[e.RowIndex].Selected = true;
                    foreach (Playlist playlist in _allPlaylists)
                    {
                        menu.Items.Add(new PlaylistToolStripItem(playlist, music));
                    }
                    menu.Show(new Point(MousePosition.X + 30, MousePosition.Y - 30));
                }
            };
            PlaylistToolStripItem.Click += (sender, e) =>
            {
                if (sender is PlaylistToolStripItem tsmiPlus)
                {
                    Debug.WriteLine($"Clicked Playlist: {tsmiPlus.Playlist.Name} Music: {tsmiPlus.Music.Name}");
                    if(tsmiPlus.Checked) tsmiPlus.Playlist.Remove(tsmiPlus.Music);
                    else tsmiPlus.Playlist.Add(tsmiPlus.Music);
                }
            };

            #region F O R M A T    C O L U M N S
            _allMusic.Add(new Music());
            dataGridViewMusic.Columns[nameof(Music.Name)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMusic.Columns[nameof(Music.Artist)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            var c = dataGridViewMusic.Columns[nameof(Music.Volume)];
            c.HeaderText = string.Empty;
            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c.Width = 60;
            _allMusic.Clear();
            #endregion F O R M A T    C O L U M N S

            // Add music to test
            _allMusic.Add(new Music { Name = "Who's That Girl", Artist = "kiddo" });
            _allMusic.Add(new Music { Name = "Mazerati", Artist = "LIZOT, Paradigm and Bella X" });
            _allMusic.Add(new Music { Name = "Sorry to Me Too", Artist = "Julia Michaels" });

            _allPlaylists.Add(new Playlist("Playlist 1") { _allMusic[0], _allMusic[1] });
            _allPlaylists.Add(new Playlist("Playlist 2") { _allMusic[1], _allMusic[2] });
            _allPlaylists.Add(new Playlist("Playlist 3") { _allMusic[0], _allMusic[2] });
        }
        BindingList<Music> _allMusic = new BindingList<Music>();
        List<Playlist> _allPlaylists = new List<Playlist>();
    }
    class Music
    {
        public string Name { get; internal set; }
        public string Artist { get; internal set; }
        public int Volume { get; set; } = 75;
    }
    class Playlist : List<Music>
    {
        public Playlist(string name) => Name = name;
        public string Name { get; }
        public static implicit operator string(Playlist playlist) => playlist.Name;
    }
    class PlaylistToolStripItem : ToolStripMenuItem
    {
        public PlaylistToolStripItem(Playlist playlist, Music music)
        {
            Playlist = playlist;
            Music = music;
            Text = playlist.Name;
            Checked = playlist.Contains(music);
            base.Click += Click;            
        }
        public Playlist Playlist { get; }
        public Music Music { get; }
        public static new event EventHandler Click;
    }
}
