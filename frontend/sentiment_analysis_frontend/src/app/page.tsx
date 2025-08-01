import Link from "next/link";
import styles from './styles.module.css';
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { ReviewTriggerHoC } from "./(hoc)/(review)/review-trigger.hoc";
import { ReviewDrawerHoC } from "./(hoc)/(review)/review-drawer.hoc";
import { AdminDrawerHoc } from "./(hoc)/(admin)/admin-drawer.hoc";
import { AdminTriggerHoC } from "./(hoc)/(admin)/admin-trigger.hoc";

export default function Home() {
  return (
    <div className={styles.Container}>
     <div className={styles.CardContainer}>
        <Card >
          <CardHeader>
            <CardTitle className={styles.CardTitle}>
              <img src="/assets/home/review.png"
                className={styles.CardTitleImage}
                height="200"
                width="300"
              />
            </CardTitle>
          </CardHeader>
          <CardContent>
            <p>Acesse a área de review do produto</p>
            <CardDescription>
              Avalie de acordo com sua experiência
            </CardDescription>
          </CardContent>
          <CardFooter>
            <ReviewTriggerHoC />
          </CardFooter>
        </Card>
      </div>
      <div className={styles.CardContainer}>
        <Card >
          <CardHeader>
            <CardTitle className={styles.CardTitle}>
              <img src="/assets/home/admin.png"
                className={styles.CardTitleImage}
                height="300"
                width="300"
              />
            </CardTitle>
          </CardHeader>
          <CardContent>
            <p>Acesse a área de administrador</p>
            <CardDescription>
              Reviews em tempo real
            </CardDescription>
          </CardContent>
          <CardFooter>
             <AdminTriggerHoC />
          </CardFooter>
        </Card>
      </div>
      <ReviewDrawerHoC />
      <AdminDrawerHoc />
    </div>
  );
}
