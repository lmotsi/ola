

document.addEventListener('DOMContentLoaded', function() {
    /* fetch("songs.json")
    .then(response => response.json())
    .then(data => {
        const songListContainer = document.getElementById('song-list');
        data.forEach(song => {
            console.log(song);
            const listItem = document.createElement('li');
            listItem.classList.add('song-item');
            listItem.textContent = song.title;
            songListContainer.appendChild(listItem);
        });
    })
    .catch(error => console.error('Error fetching JSON: ', error));
*/

    async function fetchData() {
        try {
            const response = await fetch("http://localhost:5108/priest");
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
           const data = await response.json();
            // Assuming your API returns JSON with a 'name' property
            document.getElementById('priest').innerHTML = data.name;
        } catch (error) {
            console.error('Error fetching data:', error);
            document.getElementById('priest').innerHTML = 'Error fetching data';
        }
    }

    fetchData();
}

)