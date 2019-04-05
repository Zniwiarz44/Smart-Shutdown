# Smart-Shutdown

Features:
- Countdown timer.
- Ability to Pause, Abord and continue the countdown.
- Shutdown using windows shutdown window.
- Shutdown based on network traffic (Download).
- Force shutdown (Time has to be more than 1sec).

Application will minimize to system tray and continue selected action.

Note: 
- If you close the application with timer counting down your system will not shutdown. The countdown will be aborted.
- If you close the application with windows counting down, not the application you can use the application to abort the shutdown.
 
Current limitations:
- When user logs off (Win+L) program will not shutdown the system. To shutdown user has to select Use windows closing window. That way even when logged off system will shutdown.

Version 1.1.0

Changes
• Separated business logic from interface.
• Added multithreading.
• Each section of time is updated independently.
• Added option to enter minimum speed before shutdown.
• Added dropdown with data transfer speed rate.
• Minimum transfer speed can be updated at runtime.
• Transfer can be updated at runtime.
• Speed is displayed in bits/sec or bytes/sec based on dropdown selection.
• Added support for draging the window with left click on the main panel.

Bugfixes
• Fixed issue when decresing time in seconds will incorrectly update the time display.
• Fixed network usage not being detected when connected via ethernet.
• Fixed icon not dissapering from system tray after closing the application.