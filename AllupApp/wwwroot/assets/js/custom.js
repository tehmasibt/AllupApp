$(document).ready(function () {
    //AddBasket
    $(".addToBasket").click(function (ev) {
        ev.preventDefault();
        var id = $(this).data("id");
        console.log(id);
        axios.get("/basket/addbasket?id=" + id)
            .then(function (datas) {
                $(".mini-cart").html(datas.data);
            })
    })

    

    //Search
    $(document).on("keyup", "#searchInput", function () {
        $("#searchList").html("");
        let searchValue = $(this).val();
        let categoryId = $("#selectSearch").find(":selected").val();
        if (searchValue.trim().length > 3)
        {
            axios.get("/product/searchProduct?categoryId=" + categoryId + "&search=" + searchValue)
                .then(function (datas) {
                    $("#searchList").html(datas.data)
                })
        }
    })
    $(document).on("change", "#selectSearch", function () {
        $("#searchInput").val("");
        $("#searchList").html("");
    })


    //Modal
    $(".productModal").click(function (ev) {
        ev.preventDefault();
        let url = $(this).attr("href");
        axios.get(url)
            .then(function (response) {
                // handle success
                $(".modal-body").html(response.data);
                $('.quick-view-image').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    dots: false,
                    fade: true,
                    asNavFor: '.quick-view-thumb',
                    speed: 400,
                });

                $('.quick-view-thumb').slick({
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    asNavFor: '.quick-view-image',
                    dots: false,
                    arrows: false,
                    focusOnSelect: true,
                    speed: 400,
                });
            })
    })
})