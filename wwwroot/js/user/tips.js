const buttons = document.querySelectorAll(".category-btn");
const cards = document.querySelectorAll(".tip-card");

buttons.forEach(button => {

    button.addEventListener("click", () => {

        buttons.forEach(btn => btn.classList.remove("active"));
        button.classList.add("active");

        const category = button.dataset.category;

        cards.forEach(card => {

            if (category === "all" || card.dataset.category === category) {

                card.classList.remove("hide");

                setTimeout(() => {
                    card.classList.add("show");
                }, 50);

            }
            else {

                card.classList.remove("show");
                card.classList.add("hide");

            }

        });

    });

});