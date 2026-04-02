const API_URL = window.location.origin + "/api";

// --- 1. НАВІГАЦІЯ ТА ВХІД ---
function showPage(pageId) {
    document.querySelectorAll('section').forEach(s => {
        s.classList.add('hidden');
        s.classList.remove('active');
    });
    
    const target = document.getElementById(pageId);
    if(target) {
        target.classList.remove('hidden');
        target.classList.add('active');
    }
    
    if (pageId === 'guest-view') {
        const dateInput = document.getElementById('filter-date');
        if (dateInput && !dateInput.value) dateInput.valueAsDate = new Date();
        loadSchedule();
    }
}

// ВХІД ЗА ПАРОЛЕМ 123
function handleLogin() {
    const pass = document.getElementById('password').value;
    const errorBox = document.getElementById('login-error');

    if (pass === "123") {
        errorBox.innerText = "";
        // Очищуємо поле пароля перед переходом
        document.getElementById('password').value = ""; 
        
        // Встановлюємо підпис, що це Адмін (оскільки логіна немає, пишемо просто Адмін)
        const userRoleLabel = document.getElementById('user-role-label');
        if(userRoleLabel) userRoleLabel.innerText = "Режим: Адміністратор";
        
        showPage('admin-view');
    } else {
        errorBox.innerText = "Неправильний пароль! Спробуйте 123.";
    }
}

// --- 2. ДОПОМІЖНІ ДАНІ ---
function getDayName(dateString) {
    const days = ['Неділя', 'Понеділок', 'Вівторок', 'Середа', 'Четвер', 'П\'ятниця', 'Субота'];
    return days[new Date(dateString).getDay()];
}

const bellSchedule = {
    1: "08:30 - 09:50", 2: "10:00 - 11:20", 3: "11:50 - 13:10", 4: "13:20 - 14:40",
    5: "15:00 - 16:20", 6: "16:30 - 17:50", 7: "18:00 - 19:20", 8: "19:30 - 20:50"
};

// --- 3. РОЗКЛАД: ДЕНЬ І ТИЖДЕНЬ ---
function toggleViewMode() {
    const mode = document.getElementById('view-type').value;
    document.getElementById('day-table').classList.toggle('hidden', mode !== 'day');
    document.getElementById('week-table').classList.toggle('hidden', mode !== 'week');
    loadSchedule();
}

async function loadSchedule() {
    const mode = document.getElementById('view-type') ? document.getElementById('view-type').value : 'day';
    if (mode === 'day') await loadDailySchedule();
    else await loadWeeklySchedule();
}

async function loadDailySchedule() {
    const date = document.getElementById('filter-date').value;
    const groupId = document.getElementById('filter-group').value;
    const teacherId = document.getElementById('filter-teacher').value;
    const subjectId = document.getElementById('filter-subject').value;
    
    const tbody = document.getElementById('schedule-body-day');
    if(!tbody) return;
    tbody.innerHTML = "<tr><td colspan='7' style='text-align:center;'>Завантаження...</td></tr>";

    try {
        let url = `${API_URL}/Schedule?date=${date}`;
        if (groupId) url += `&groupId=${groupId}`;
        if (teacherId) url += `&teacherId=${teacherId}`;
        if (subjectId) url += `&subjectId=${subjectId}`;

        const res = await fetch(url);
        const data = await res.json();
        tbody.innerHTML = "";
        
        if (data.length === 0) {
            tbody.innerHTML = "<tr><td colspan='7' style='text-align:center;'>На цей день занять немає</td></tr>";
            return;
        }

        const dayName = getDayName(date);
        data.forEach(item => {
            const timeStr = bellSchedule[item.lessonNumber] || "—";
            const tag = item.lessonType ? `<span style='font-size:0.8em; color:gray'>(${item.lessonType})</span>` : "";
            tbody.innerHTML += `<tr>
                <td><b>${dayName}</b></td> <td>${item.lessonNumber}</td> <td>${timeStr}</td>
                <td><b>${item.subjectName}</b> ${tag}</td> <td>${item.teacherName}</td>
                <td><span class="badge">${item.groupName}</span></td> <td>${item.audienceNumber}</td>
            </tr>`;
        });
    } catch (e) { tbody.innerHTML = "<tr><td colspan='7' style='color:red;'>Помилка завантаження</td></tr>"; }
}

async function loadWeeklySchedule() {
    const dateInput = document.getElementById('filter-date').value;
    const groupId = document.getElementById('filter-group').value;
    const teacherId = document.getElementById('filter-teacher').value;
    const subjectId = document.getElementById('filter-subject').value;
    
    const tbody = document.getElementById('schedule-body-week');
    if(!tbody || !dateInput) return;

    const selDate = new Date(dateInput);
    const dayOfW = selDate.getDay() || 7; 
    const mon = new Date(selDate); mon.setDate(selDate.getDate() - dayOfW + 1); 
    const fri = new Date(mon); fri.setDate(mon.getDate() + 4); 

    const startStr = mon.toISOString().split('T')[0];
    const endStr = fri.toISOString().split('T')[0];

    tbody.innerHTML = "<tr><td colspan='6' style='text-align:center;'>Завантаження...</td></tr>";

    try {
        let url = `${API_URL}/Schedule/week?startDate=${startStr}&endDate=${endStr}`;
        if (groupId) url += `&groupId=${groupId}`;
        if (teacherId) url += `&teacherId=${teacherId}`;
        if (subjectId) url += `&subjectId=${subjectId}`;

        const res = await fetch(url);
        const data = await res.json();
        tbody.innerHTML = "";
        
        const days = ['Понеділок', 'Вівторок', 'Середа', 'Четвер', 'П\'ятниця'];
        
        for (let lesson = 1; lesson <= 8; lesson++) {
            let rowHtml = `<tr><td class="time-cell"><b>${lesson}</b><br><span>${bellSchedule[lesson] || ""}</span></td>`;
            days.forEach(dayName => {
                const lessonsHere = data.filter(d => d.dayOfWeek === dayName && d.lessonNumber === lesson);
                if (lessonsHere.length > 0) {
                    let cellContent = lessonsHere.map(l => `
                        <div class="lesson-card">
                            <div class="subject">${l.subjectName}</div>
                            <div class="details">
                                👥 Гр: ${l.groupName}<br>👤 Викл: ${l.teacherName}<br>🚪 Каб: ${l.audienceNumber}
                            </div>
                        </div>
                    `).join('');
                    rowHtml += `<td>${cellContent}</td>`;
                } else { rowHtml += `<td class="empty-cell">—</td>`; }
            });
            tbody.innerHTML += rowHtml + `</tr>`;
        }
    } catch (e) { tbody.innerHTML = "<tr><td colspan='6'>Помилка завантаження тижня</td></tr>"; }
}

// --- 4. ПАНЕЛЬ АДМІНА ТА ГЕНЕРАЦІЯ ---
async function submitNewSchedule(event) {
    event.preventDefault();
    const msgBox = document.getElementById('admin-message');
    msgBox.style.color = "black"; msgBox.innerText = "Збереження...";

    const dateVal = document.getElementById('admin-date').value;
    const newSchedule = {
        date: dateVal,
        dayOfWeek: getDayName(dateVal),
        lessonNumber: parseInt(document.getElementById('admin-lesson-number').value),
        groupId: parseInt(document.getElementById('admin-group').value),
        teacherId: parseInt(document.getElementById('admin-teacher').value),
        subjectId: parseInt(document.getElementById('admin-subject').value),
        audienceId: parseInt(document.getElementById('admin-audience').value),
        lessonType: document.getElementById('admin-lesson-type').value,
        isEvenWeek: 0
    };

    try {
        const response = await fetch(`${API_URL}/Schedule`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newSchedule)
        });
        if (response.ok) {
            msgBox.style.color = "green";
            msgBox.innerText = "✅ Пару успішно додано!";
            document.getElementById('admin-lesson-number').value = "";
        } else {
            const err = await response.text();
            msgBox.style.color = "red"; msgBox.innerText = "❌ Помилка: " + err;
        }
    } catch (e) { msgBox.style.color = "red"; msgBox.innerText = "❌ Помилка зв'язку з сервером."; }
}

async function autoGenerateSchedule() {
    const dateInput = document.getElementById('auto-generate-date').value;
    const msgBox = document.getElementById('generate-message');
    if (!dateInput) { msgBox.style.color = "red"; msgBox.innerText = "Оберіть дату!"; return; }

    const selDate = new Date(dateInput);
    const dayOfW = selDate.getDay() || 7; 
    const mon = new Date(selDate); mon.setDate(selDate.getDate() - dayOfW + 1); 
    const mondayStr = mon.toISOString().split('T')[0];

    msgBox.style.color = "black";
    msgBox.innerText = "⏳ Генеруємо розклад...";

    try {
        const response = await fetch(`${API_URL}/Schedule/generate-auto?startMondayDate=${mondayStr}`, { method: 'POST' });
        if (response.ok) {
            const result = await response.json();
            msgBox.style.color = "green"; msgBox.innerText = `✅ ${result.message}`;
        } else { msgBox.style.color = "red"; msgBox.innerText = "❌ Помилка генерації."; }
    } catch (e) { msgBox.style.color = "red"; msgBox.innerText = "❌ Помилка зв'язку."; }
}

async function initAllFilters() {
    try {
        const [gRes, tRes, sRes, aRes] = await Promise.all([
            fetch(`${API_URL}/Group`), fetch(`${API_URL}/Teacher`), fetch(`${API_URL}/Subject`), fetch(`${API_URL}/Audience`)
        ]);

        const groups = await gRes.json();
        const teachers = await tRes.json();
        const subjects = await sRes.json();
        const audiences = aRes.ok ? await aRes.json() : [];

        const fillSelect = (id, data, textProp) => {
            const el = document.getElementById(id);
            if(el) data.forEach(d => el.innerHTML += `<option value="${d.id}">${d[textProp]}</option>`);
        };

        fillSelect('filter-group', groups, 'name'); fillSelect('admin-group', groups, 'name');
        fillSelect('filter-teacher', teachers, 'fullName'); fillSelect('admin-teacher', teachers, 'fullName');
        fillSelect('filter-subject', subjects, 'name'); fillSelect('admin-subject', subjects, 'name');
        fillSelect('admin-audience', audiences, 'number');
    } catch (e) { console.error("Помилка фільтрів", e); }
}

document.addEventListener('DOMContentLoaded', initAllFilters);