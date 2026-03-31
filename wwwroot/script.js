const API_URL = "http://localhost:5062/api"; // ПЕРЕВІР СВІЙ ПОРТ

// Перемикання сторінок
function showPage(pageId) {
    document.querySelectorAll('section').forEach(s => s.classList.add('hidden'));
    document.getElementById(pageId).classList.remove('hidden');
    
    if (pageId === 'guest-view') {
        // Встановлюємо сьогоднішню дату за замовчуванням
        document.getElementById('filter-date').valueAsDate = new Date();
        loadSchedule();
    }
}

// Логіка входу (Обробка помилки на фронті)
async function handleLogin() {
    const user = document.getElementById('username').value;
    const pass = document.getElementById('password').value;
    const errorBox = document.getElementById('login-error');

    errorBox.innerText = ""; // Очищуємо стару помилку

    if (!user || !pass) {
        errorBox.innerText = "Будь ласка, заповніть усі поля!";
        return;
    }

    try {
        const response = await fetch(`${API_URL}/Auth/login`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username: user, password: pass })
        });

        if (response.ok) {
            document.getElementById('user-role-label').innerText = "Адміністратор: " + user;
            showPage('guest-view');
        } else {
            // Виводимо помилку на сайті, якщо сервер відхилив логін
            errorBox.innerText = "Неправильний логін або пароль!";
        }
    } catch (e) {
        errorBox.innerText = "Помилка зв'язку з сервером. Перевірте, чи запущений API.";
    }
}

// Завантаження розкладу
async function loadSchedule() {
    const date = document.getElementById('filter-date').value;
    const group = document.getElementById('filter-group').value;

    const tbody = document.getElementById('schedule-body');
    tbody.innerHTML = "<tr><td colspan='7'>Завантаження...</td></tr>";

    try {
        const response = await fetch(`${API_URL}/Schedule?date=${date}&groupId=${group}`);
        const data = await response.json();

        tbody.innerHTML = "";
        data.forEach(item => {
            const row = `<tr>
                <td>Понеділок</td> <td>${item.lessonNumber}</td>
                <td>08:30 - 09:50</td> <td>${item.subjectName}</td>
                <td>${item.teacherName}</td>
                <td>${item.groupName}</td>
                <td>${item.audienceNumber}</td>
            </tr>`;
            tbody.innerHTML += row;
        });
    } catch (e) {
        tbody.innerHTML = "<tr><td colspan='7' style='color:red'>Не вдалося завантажити розклад</td></tr>";
    }
}