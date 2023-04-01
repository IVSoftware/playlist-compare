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
            dataGridViewMusic.DataSource = Songs;
            dataGridViewMusic.CellMouseDown += (sender, e) =>
            {
                if (e.Button.Equals(MouseButtons.Right) && !e.RowIndex.Equals(-1))
                {
                    var menu = new ContextMenuStrip();
                    var song = Songs[e.RowIndex];
                    dataGridViewMusic.ClearSelection();
                    dataGridViewMusic.Rows[e.RowIndex].Selected = true;
                    foreach (Playlist playlist in _allPlaylists)
                    {
                        menu.Items.Add(new PlaylistToolStripItem(playlist, song));
                    }
                    menu.Show(new Point(MousePosition.X + 30, MousePosition.Y - 30));
                }
            };
            PlaylistToolStripItem.Click += (sender, e) =>
            {
                if (sender is PlaylistToolStripItem tsmiPlus)
                {
                    Debug.WriteLine($"Clicked Playlist: {tsmiPlus.Playlist.Name} Song: {tsmiPlus.Song}");
                    if(tsmiPlus.Checked) tsmiPlus.Playlist.Remove(tsmiPlus.Song);
                    else tsmiPlus.Playlist.Add(tsmiPlus.Song);
                }
            };

            #region F O R M A T    C O L U M N S
            Songs.Add(new Music());
            dataGridViewMusic.Columns[nameof(Music.Name)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMusic.Columns[nameof(Music.Artist)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            var c = dataGridViewMusic.Columns[nameof(Music.Volume)];
            c.HeaderText = string.Empty;
            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c.Width = 60;
            Songs.Clear();
            #endregion F O R M A T    C O L U M N S

            // Add music to test
            Songs.Add(new Music { Name = "Who's That Girl", Artist = "kiddo" });
            Songs.Add(new Music { Name = "Mazerati", Artist = "LIZOT, Paradigm and Bella X" });
            Songs.Add(new Music { Name = "Sorry to Me Too", Artist = "Julia Michaels" });

            _allPlaylists.Add(new Playlist("Playlist 1") { Songs[0], Songs[1] });
            _allPlaylists.Add(new Playlist("Playlist 2") { Songs[1], Songs[2] });
            _allPlaylists.Add(new Playlist("Playlist 3") { Songs[0], Songs[2] });
        }
        BindingList<Music> Songs = new BindingList<Music>();
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
        public PlaylistToolStripItem(Playlist playlist, Music song)
        {
            Playlist = playlist;
            Song = song;
            Text = playlist.Name;
            Checked = playlist.Contains(song);
            base.Click += Click;
        }
        public Playlist Playlist { get; }
        public Music Song { get; }
        public static new event EventHandler Click;
    }
}
