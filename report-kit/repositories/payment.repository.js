import db from "../config/database.js";

export default async function getPaymentData() {
    const payments = await db("Users as u")
        .join("Payments as p", "u.UserId", "p.UserId")
        .select(
            "u.UserName",
            "p.PaidAmount",
            "p.PaymentDate"
        );

    const total = payments.reduce(
        (sum, payment) => sum + Number(payment.PaidAmount || 0),
        0
    );

    const formattedPayments = payments.map(payment => ({
        ...payment,
        PaymentDate: new Date(payment.PaymentDate).toLocaleDateString("en-GB"),
    }));

    return {
        total: total,
        payments: formattedPayments
    }
}