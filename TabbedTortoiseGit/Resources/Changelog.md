# !!!ATTENTION!!!
If you've updated Tabbed TortoiseGit but your settings were lost, go to Settings -> Restore Settings.
This should restore your settings from the most recent settings file.

# Version 0.36.0
* Handle uninitialized submodules as modified submodules for Fast(er) Submodule Update.
* Check for TortoiseGitProc.exe in default location before checking PATH.
* Add option to specify TortoiseGitProc.exe location manually.

# Version 0.35.0
* Added keyboard shortcut to hide/show references display.

# Version 0.34.0
* Added references display for current log (this can be disabled in the settings).

# Version 0.33.0
* Correct issue with TabChanged event not firing when selected tab is removed.
* Created changelog.

# Version 0.32.0
* Use favorite repos directory color if no other favorite exists for tab.
* Improve tinted icon...again.
* Improve favorite menu strip context menus.
* Suggest favorite name from selected favorite item.
* Improve setting change handling.
* Include all nested repos under a favorite repos directory.

# Version 0.31.0
* Re-implement drag/drop for Favorites Manager.
* Implementing repos directories.
* Working on improving Favorites.
* Make icon closer match color of favorite repo color.
* Add ability to edit favorites from favorites bar.
* Making suggested updates.
* Fixing nullability issues.
* Add nullable annotation.
* Updating to Visual Studio 2019/.NET Framework 4.8.

# Version 0.30.0
* Added check for if TortoiseGit is on PATH.
* Add handling for configuration exceptions.
* Fix label anchor for ProgressDialog.
* Improved FasterFetch progress start.
* Remove unnecessary designer property.
* Attempt to speed up Fast Submodule dialog loading times.
* Switch to square tabs.
* Hide favorites bar if there are no favorites.
* Improve handling of submodules menu.

# Version 0.29.0
* Added "refretch" button.
* Added way to easily open submodules of current repo.

# Version 0.28.0
* Added ability to open repo with specific references.
* Added Diff git action.
* Update ProgressDialog to kill tasks on cancel.
* Attempt to fix issue where fetch/submodule update actions do not work correctly when started from a non-root repo directory.
* Added ability to duplicate selected tab.
* Improved custom actions.
* Added option to set current working directory for custom action.
* Added option to refresh log after a custom action completes.
* Added option to show progress dialog for custom action.
* Added option to not create a new window.

# Version 0.27.0
* Use string interpolation and nameof() where possible.
* Fix error when attempting to retrieve latest version of TabbedTortoiseGit.
* Remove nuisance error messages due to unset keyboard shortcuts.
* Add Custom Actions.

# Version 0.26.0
* Add polling method to find TortoiseGit processes.

# Version 0.25.0
* Move "Show Debug Log" button from About dialog to Options menu.
* Created Faster Submodule Update.
* Add support for additional tasks in ProgressDialog.
* Abstracted ProcessProgressDialog to ProgressDialog.
* Created initial Faster Submodule Update.

# Version 0.24.0
* Fix "Update Submodules" button not being enabled when only one submodule is selected.

# Version 0.23.0
* Remove unneeded constructors.
* Forward F5, Down Arrow, and Up Arrow to TortoiseGit.
* Added KeyboardShortcut for Faster Fetch.
* Moved shortcut handling function.
* Prevent FastFetch and FastSubmoduleUpdate from blocking TabbedTortoiseGit.
* Only refresh log after Git action if action was actually taken.

# Version 0.22.0
* Updated SettingsForm with checkbox for confirming before FasterFetch.
* Switched to using TaskDialog for closing confirmation.
* Use BackgroundWorker instead of Timer for checking for modified repos.
* Prevent keyboard shortcuts possibly being overwritten.
* Added FasterFetch git action.
* Prevent notify icon from persisting in system tray after close.
* Fixed issue with Tab tool tip when dragging.
* Attempt to kill TortoiseGit process gracefully.
* Added colored icons to tabs.
* Display tooltip for Tab.
* Unified dialogs to not show in the taskbar.
* Fixed SelectedTab not propagating when pulling tab out.

# Version 0.21.0
* Improved drag/dropping within FavoritesManagerDialog.
* Added icon coloring to match currently selected favorite repo.
* Added search utility properties to TreeNode<>.
* Make selected references unique.
* Minor improvements to JSON settings serialization.
* Added ability to add references to FavoriteRepo.
* Fixed TortoiseGit log not being captured when using - command line argument.
* Added ability to set color of Favorites.
* Support displaying/favoriting single files.
* Added logging to Common project.
* Added shortcuts for git actions.
* Updated HotKey handling for multiple instances of TabbedTortoiseGitForm.
* Prevent new form being opened when dragging into empty TabControl.
* Working on supporting tearing tab out.
* Update Tab drag/drop to work between forms.
* Initial changes to allow multiple instances of Tabbed TortoiseGit.

# Version 0.20.2
* Fixed forwarded hotkeys not working.

# Version 0.20.1
* Prevent favorite repo menus from not closing.

# Version 0.20.0
* Added option to set default tab font and color.
* Retain selected tab when closing other tab.
* Added "reopen closed tab" hotkey.
* Added keyboard shortcuts for next tab, previous tab, and close tab.
* Fixed keyboard shortcuts.
* Fixing HotKeys.
* Refresh TortoiseGit after Git actions.
* Added ability to middle-click favorite folder to open all contained favorites.
* Added context menu for all Favorite items.
* Added drag/drop to Favorites manager.

# Version 0.19.0
* Do not highlight newly-added Favorite folder.
* Continue prompting for valid Git repo directory when adding favorite and an invalid directory is selected.
* Move intensive operations out of Form_Load.
* Moved "Check Modified Submodules By Default" checkbox to FastSubmoduleUpdateForm.
* Added elapsed time and progress bar to ProcessProgressDialog.
* Fixed Tabbed TortoiseGit not closing after last tab was closed.

# Version 0.18.0
* Fixing favorites update.
* Minor renaming/UI updates.
* Finalizing Favorites Manager.
* Working on stuff.
* Undo moving Favorites menu strip to TabControl.

# Version 0.17.0
* Add auto-update prompt.
* Added option for where to display Favorites menu.
* Moved Favorites menu strip to TabControl.
* Fixed dragging issues.
* Fixed issues with adding/removing selected tab.
* Minor fixes after re-implementation.
* Re-implemented TabControl functions.
* Re-implemented ControlCollection for TabControl.
* Moved/renamed TabHeaderDragDropHelper to TabControlDragDropHelper.
* Re-implemented TabCollection.
* Added ability to drag repo folder into application window to open tab.

# Version 0.16.0
* Added option to close window after last tab is closed.
* Attempting to improve new tab button.
* Added "X" close button to tabs.

# Version 0.15.0
* Added OptionsMenu to TabControl.
* Add simple highlight indications to tabs and new tab button.
* Add check for matching assembly versions.
* Fixing exception caused by attempting to delete registry item that does not exist.
* Fix tab dragging behaving oddly when dragging outside of tab bar.
* Fix favorite tabs not opening.

# Version 0.14.0
* Better organized logs.
* Added option to remove favorited repo from favorites bar.
* Added option to indicate modified tabs.
* Added a few utility extension methods.

# Version 0.13.0
* Separated common utilities into new project.
* Limit drag range of tabs.
* Improved tab dragging animation.
* Do not prompt to confirm closing if closed to system tray or no tabs are opened.
* Made closing to system tray optional.
* Do not select modified submodules if user has already interacted with submodule list.
* Added developer debug settings for hit testing.
* Minor drawing improvements to TabControl.

# Version 0.12.0
* Corrected error in PointPath HitTest.
* Fix tab not being selected until mouse up.
* Fix progress dialog not autoscrolling with output.
* Fix retrieving of modified submodules not working on older versions of Git.
* Built installer with new TabControl.
* Improved menu display.
* Fix incorrect tab page sizing.
* Hide Text for TabControl.
* Removed ExtendedTabControl.
* Added New Tab and Tab context menu to new TabControl.
* Switching to new TabControl.
* Improved tab text drawing.
* Converting to using PointPath instead of GraphicsPath.
* Separating tab drawing logic.
* Removed MenuStrip support.
* Added default middle click handling.
* Working on more general tab control.
* Working on tabs.
* More work on better tabs.
* Prevent NPE when no TabHeader contains no tabs.
* Working on making tab interface better.
* Simplified log removal process.

# Version 0.11.0
* Added update option to About dialog.
* Simplified progress dialog name from Fast Submodule Update.
* Added progress option to Fast Fetch.
* Added Fast Submodule Update max processes setting handling.
* Added Fast Fetch git action.
* Added setting to select modified submodules by default.
* Added ability to only show modified submodules to Fast Submodule Update.
* Remove keyboard shortcuts.

# Version 0.10.1
* Disable keyboard shortcut.

# Version 0.10.0
* Added initial keyboard shortcut.
* Async all the way.
* Better checkbox list selection.
* Prevent buttons from staying disabled in FastSubmoduleUpdate form when selecting modified submodules.

# Version 0.9.0
* Renamed Default Repos to Startup Repos.
* Added option to re-Startup Repos when application is re-opened from Task Tray.
* Added max processes for FastSubmoduleUpdate.
* Added settings validation.
* Fix typo.
* Added option to select modified submodules in FastSubmoduleUpdate.
* Added options to submodule update init, recursive, and force.

# Version 0.8.0
* Improved run on startup.

# Version 0.7.0
* Improved settings loading.
* Re-arranged SettingsForm.
* Moved Open Log File to About box.
* Added link to Github to About box.
* Added logging to DragDropHelper.
* Use DragDropHelper for ExtendedTabControl.
* Improved git actions settings.
* Added option to cancel Fast Submodule Update.
* Prompt to confirm closing before closing form not just when exiting application.

# Version 0.6.0
* Add Tabbed TortoiseGit to Programs Menu.
* Only run up to 6 submodule updates at a time.
* Add icon to dialogs.
* Center dialogs in parent.
* Prevent name collision.
* Do not assume path argument to TortoiseGit log is surrounded by quotes.
* Fixed TortoiseGit log not being captured when TabbedTortoiseGitForm had not been loaded on startup.

# Version 0.5.0
* Added logging to FastSubmoduleUpdateForm and ProcessProgressForm.
* Force cursor to end of textbox for ProcessProgressForm.
* Added option to SettingsForm for confirm on close.
* Prevent log from resizing when form is minimized.
* Added FastSubmoduleUpdate.

# Version 0.4.0
* Prevent exception on ManagementEventWatcher finalization.
* Added more log statements.
* Only wait for main window handle before consuming TortoiseGit log.

# Version 0.3.0
* Added initial logging.
* Fixed Submodule Update command not working.
* Added close confirmation dialog.
* Corrected OK/Cancel button positions.
* Position input dialog in middle of parent on show.
* Prevent application from showing on computer startup.
* Added installation link to README.

# Version 0.2.0
* Maintain user settings across version changes.
* Added favorite repos.
* Added application description.
* Create README.md

# Version 0.1.0
* Update version numbers to match.
* Added settings to choose which git actions display in tab context menu.
* Add Git actions to tab context menu.
* Improve recent repos.
* Allow selecting non-root repo folders.
* Save window state after change.
* Resize form if too small to fit log.
* Added ability to re-order tabs.
* Removed unused resource.
* Added ability to open location of repo by right-clicking tab.
* Added setup project.
* Removed Costura.Fody
* Attempting to speed up application start.
* Added icon and About.
* Added maximum number of recent repos setting.
* Open default repos if no logs are open on show.
* Added Default Repos.
* Added option to retain logs on close.
* Minor restructures.
* Restructured ExtendedTabControl.
* Restructured TabbedTortoiseGitForm event handlers.
* Add exe.
* Make application single instance.
* Added NotifyIcon to allow application to capture logs when hidden.
* Application now listens for opened logs.
* Added right-click context menu to new tab button.
* Removed path from TortoiseGit executable.
* Added form size and location settings.
* Remove Git library.
* Adding settings.
* Improved mouse actions.
* Added ability to close and open new tabs.
* Add project files.
* Add .gitignore and .gitattributes.