document
  .getElementById("generateButton")
  .addEventListener("click", function () {
    var inputContainer = document.getElementById("inputContainer");

    // Skapa en ny input-tagg
    var inputTag = document.createElement("input");
    inputTag.setAttribute("type", "radio");
    inputTag.setAttribute("asp-for", "IsInSweden");
    inputTag.setAttribute("value", "false");
    inputTag.setAttribute("class", "form-radio");

    // Lägg till input-taggen i container-elementet
    inputContainer.appendChild(inputTag);
  });
