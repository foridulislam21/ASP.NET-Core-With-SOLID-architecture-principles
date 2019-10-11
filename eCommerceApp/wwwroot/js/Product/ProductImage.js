$(document).ready(() => {
    let inputs = [];
    let name = "file";

    let loadImageFromInputs = () => {
        $("#ImageHolder").empty();
        if (!FileReader) {
            console.log("Can't load file in navigator");
            return;
        }

        inputs.forEach(i => {
            Array.from(i.files).forEach(f => {
                let fr = new FileReader();
                fr.onload = function () {
                    $("#ImageHolder").append($("<img>",
                        {
                            class: "img-thumbnail mr-1 image",
                            src: fr.result
                        })
                        .css({ width: "90px", height: "110px" })
                    );
                }
                fr.readAsDataURL(f);
            });
        });
    }
    $("#inputMusk").click(() => {
        let newInput = $("<input>",
            {
                type: "file",
                name: name,
                id: name,
                multiple: true,
                accept: "image/x-png,image/gif,image/jpeg,image/jpg"
            }).css({ width: "100px", height: "150px", position: "absolute", opacity: "0" });
        newInput.change((e) => { loadImageFromInputs() });
        inputs.push(newInput[0]);
        $("#holder").append(newInput);
        newInput.click();
    });

    $("#holder").submit((e) => {
        e.preventDefault();
        e.target.submit();
    });
});