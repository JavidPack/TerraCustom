# TerraCustom

## About

TerraCustom is a tool for Terraria that facilitates custom Terraria world generation. TerraCustom aims to allow users to experience worlds that can be varied and tweaked to personal preference for novel Terraria experiences. 

Download and installation instructions are on the forums thread.

[Forums Thread](http://forums.terraria.org/index.php?threads/unofficial-terracustom-for-1-3.35346/)

## Contributing

### Coding Guidelines

A huge goal of TerraCustom is to have the code generate exactly the same if no user options are selected. Any code changes must respect this guideline. 

### Getting the TerraCustom code

If you want to contribute to this project, you'll want to clone the repository on your computer and then run setup.bat to decompile Terraria and apply the TerraCustom patches. The patcher works with the steam *Windows* version.

**Warning:** decompiling will probably freeze your computer for a couple of hours. So you'll need to find something to do in real life until that's done.

When that's all done, you should have the TerraCustom source in the src folder. Open the solutions folder then open the TerraCustom solution.

### Committing changes

So you've made some changes to TerraCustom and want to commit them. Run setup.bat again, then *(Important) click on Format Code*. Select the src/TerraCustom folder, then wait a bit for it to format. When that's done, click on Diff TerraCustom. This will create patch files with the changes you've made. Finally, all you'll need to do is commit the patches folder.
