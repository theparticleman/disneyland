function showModal(input) {
    const dialog = document.getElementById('dialog');
    const name = document.getElementById('name');
    const wantToGo = document.getElementById('wantToGo');
    const doNotCare = document.getElementById('doNotCare');
    const doNotWantToGo = document.getElementById('doNotWantToGo');
    const rideData = data[input];
    dialog.showModal();
    name.innerHTML = rideData.name;
    wantToGo.innerHTML = rideData.wantToGo.join(", ");
    doNotCare.innerHTML = rideData.doNotCare.join(", ");
    doNotWantToGo.innerHTML = rideData.doNotWantToGo.join(", ");
}

const modalHtml = `
    <dialog id="dialog" onclick="document.getElementById('dialog').close();">
        <h1 id="name"></h1>
        <section>
            <h2>Want To Go</h2>
            <p id="wantToGo"></p>
        </section>
        <section>
            <h2>Do Not Care</h2>
            <p id="doNotCare"></p>
        </section>
        <section>
            <h2>Do Not Want To Go</h2>
            <p id="doNotWantToGo"></p>
        </section>
    </dialog>`;

document.body.insertAdjacentHTML('beforeend', modalHtml);