# Smart-Shutdown v1.0.0

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
 
TODOs:
- Implement ability to drag the window around the screen as borderless windows require addition functions.

Current limitations:
- When user logs off (Win+L) program will not shutdown the system. To shutdown user has to select Use windows closing window. That way even when logged off system will shutdown.
