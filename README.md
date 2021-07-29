# Conway's Game of Life
 Project & Portfolio I: Conway's Game of Life, by Daniel Ben Zvi, COS119-O, C202107, section 01, Full Sail University, Florida.

## My added features:
### Scrollable Universe:
 I've the feature for a scrollable universe, by default the feature is turned off and the software is set to adjust the universe to fit the graphics panel, this can be changed via the Options menu by checking the "scrollable" option thus also allowing the user to choose a custom cell size (no smaller than what would fit the graphics panel or in other words full grid view).

### QuadTree Data Model:
 The project contains both a grid and QuadTree data model for handling the universe, at the moment the solution only uses the grid model.
 I have successfully tested and used the QuadTree in my solution and the solution indeed works, however, it would seems that I'm not using my QuadTree model appropriately as the model works much slower then it should. If you wish to switch between the models you can do so by switching the model singleton value inside Program.cs to a QuadTree model instance.

### Pattern Menu:
 Within the import funtionality it is possible to select a Life Lexicon pattern for use out of a full menu table.

### Import Position:
 It is possible when selecting import to choose the top left corber position of where the pattern will be inserted in the universe ([0,0] by default), when using finite view mode; the pattern will get clipped when placed out of bounds unlike when using the toroidal view mode.
