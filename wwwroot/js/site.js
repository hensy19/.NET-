// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Profile Dropdown Toggle
document.addEventListener('click', function (e) {
    const trigger = document.getElementById('profile-trigger');
    const menu = document.getElementById('profile-menu');
    
    if (trigger && trigger.contains(e.target)) {
        menu.classList.toggle('active');
    } else if (menu && !menu.contains(e.target)) {
        menu.classList.remove('active');
    }
});
