## About
<p>OpenCiv1 project is an open source rewrite of Civilization 1 Game designed by Sid Meier and Bruce Shelley in year 1991.</p>
<p>The game logic is <b>Based on original DOS CIV I version 475.05</b> disassembly.</p>
<p>The game is still very popular and easy to play. But the obsoletness of DOS or Windows 16-bit platform 
and the bugs that have never been fixed are hindering the popularity of the game.<p>
<p>The news, discussions about this project and releases are published regularly on <a href="https://forums.civfanatics.com/threads/rewrite-of-civilization-1-source-code-openciv1-project.682623/" target="_blank">Civilization Fanatics Forum page</a></p>

## Copyright considerations
<p><b>The available code is not a full working copy of the game.</b> <b>To run OpenCiv1 you are legally required to own your own copy of the Civilization game.</b> 
<b>This is the reason that not a single file from original game is included in this GitHub repository as they are copyrighted.</b></p>

<p>The part of the game assembly code is emulated with Virtual CPU, and the rest of the code has been rewritten from scratch 
until all of the code is replaced with new copyright free code. The other resources (like graphics, music and text) 
will also be completely replaced with copyright free resources before publishing the complete game.</p>

## Current status
<p><b>The game is in working state</b>, but you have to legally own the Original game (the .txt, .pic and .pal files have to be present).
The <b>Debug mode</b> can be toggled by pressing Alt + D Key.</p>

## How to install release version of OpenCiv1
<p>The file OpenCiv1.exe should be copied directly into installed and working DOS Civilization 1 directory.
The Debug mode can be toggled by pressing Alt + D Key.</p>

<p>The only dependency is .NET 8</p>

## How to run the code
If you want to compile the code, it is assumed that:
<ul>
<li>You are using Visual Studio 2022.</li>
<li>You have .NET 8 installed.</li>
<li>For debugging you have installed DOS CIV I game at 'c:\Dos\Civ1\', or at '~/Dos/Civ1/' if you are using Linux.
It's where it's home directory resides (Images, palettes, text and save games are loaded/saved there, for now).</li>
<li>For Release mode it is expected that OpenCiv1.exe (for simlicity) is put directly into directory with resource files, 
for example: 'c:\Dos\Civ1\', '~/Dos/Civ1/' or any other path.</li>
</ul>

## Help needed
<p>All contributions are welcome.</p>
For this stage of code rewrite, the programmings skills needed are:
<ul>
<li>Moderate knowledge of assembly language,</li>
<li>Knowledge of C# language.</li>
<li>For details see: https://github.com/rajko-horvat/OpenCiv1/wiki/Introduction-to-code-translating</li>
</ul>

## Project milestones
<p>The goal is to completely rewrite the code (first stage), fix the bugs and port the code to a modern platform (second stage).</p>

### Milestones for a first stage
<ul>
<li>Reaching the initial playability of the game (passed),</li>
<li>Rewrite of the game code, functionalities and features (in progress...),</li>
<li>Archive the game code.</li>
</ul>

### Planned milestones for a second stage
<b>What will change in the new version:</b>
<ul>
<li>Porting to HTML5 platform (Web interface, online gaming),</li>
<li>Graphics (the new graphics will be as close as possible to the spirit of the original version),</li>
<li>Music/Sounds (the new music/sounds will be as close as possible to the spirit of the original version),</li>
<li>Some text where appropriate,</li>
<li>Design (Map zoom functionality, some small updates, also some dialogs will be slightly different),</li>
<li>Multilanguage capability,</li>
<li>Multiplayer capability,</li>
<li>Cheat capability,</li>
<li>Plugin capability (can override rules, graphics and music/sounds).</li>
</ul>
<b>What will stay the same:</b>
<ul>
<li>Original game rules and logic (except for established bugs),</li>
<li>Overall look and feel of the original game.</li>
</ul>

## Screenshots of the OpenCiv1 game
<p align="center">
<img src="Screenshots/Screenshot1.png" alt="Screenshot 1" /><br/>
<img src="Screenshots/Screenshot2.png" alt="Screenshot 2" /><br/>
<img src="Screenshots/Screenshot3.png" alt="Screenshot 3" /><br/>
<img src="Screenshots/Screenshot4.png" alt="Screenshot 4" /><br/>
<img src="Screenshots/Screenshot5.png" alt="Screenshot 5" /><br/>
<img src="Screenshots/Screenshot6.png" alt="Screenshot 6" /><br/>
<img src="Screenshots/Screenshot7.png" alt="Screenshot 7" /><br/>
<img src="Screenshots/Screenshot8.png" alt="Screenshot 8" /><br/>
<img src="Screenshots/Screenshot9.png" alt="Screenshot 9" /><br/>
<img src="Screenshots/Screenshot10.png" alt="Screenshot 10" /><br/>
<img src="Screenshots/Screenshot11.png" alt="Screenshot 11" /><br/>
<img src="Screenshots/Screenshot12.png" alt="Screenshot 12" /><br/>
<img src="Screenshots/Screenshot13.png" alt="Screenshot 13" /><br/>
<img src="Screenshots/Screenshot14.png" alt="Screenshot 14" /><br/>
</p>