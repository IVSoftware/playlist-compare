As I understand it, you're repopulating a context menu every time a `music` item gets a right click and the context menu is shown. Since you're creating new `ToolStripMenuItem` instances anyway, consider providing all the information needed for Add/Remove operations for the `music` item at the time of creation. One way to do this in an efficient manner is to make a custom TSMI class:

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

Making the click event `static` means that main form can subscribe to it just one time. 

    PlaylistToolStripItem.Click += (sender, e) =>
    {
        if (sender is PlaylistToolStripItem tsmiPlus)
        {
            Debug.WriteLine($"Clicked Playlist: {tsmiPlus.Playlist.Name} Song: {tsmiPlus.Song}");
            if(tsmiPlus.Checked) tsmiPlus.Playlist.Remove(tsmiPlus.Song);
            else tsmiPlus.Playlist.Add(tsmiPlus.Song);
        }
    };

***
**Context Menu Example Code**

The context menu accurately depicts the playlists that contain the right-clicked item and the add/remove behavior works as expected.

[![screenshot][1]][1]

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


  [1]: https://i.stack.imgur.com/gN363.png