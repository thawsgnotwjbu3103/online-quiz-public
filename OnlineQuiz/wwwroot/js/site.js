$(document).ready(function () {
    $("#submit").on("click", function () {
        let answers = [];
        $("input[type=radio]:checked").each(function () {
            answers.push($(this).val());
        });

        Swal.fire({
            title: 'Đồng ý nộp bài ?',
            text: "Chú ý : Sau khi nộp bài, sinh viên không thể thi lại",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Từ chối',
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: "/nop-bai",
                    dataType: "json",
                    type: "POST",
                    data: {
                        answers: answers
                    },
                    success: function () {
                    },
                    error: function () {
                    }
                })
                window.location.href = "/dashboard";
            }
        })
    })
});
